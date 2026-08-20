// HOW-TO: Apply Motion Blur to Rasterized SVG and Compare PNGs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string originalPath = "original.png";
            string filteredPath = "filtered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(originalPath));
            Directory.CreateDirectory(Path.GetDirectoryName(filteredPath));

            // Load SVG and rasterize to original PNG
            using (Image image = Image.Load(inputPath))
            {
                var svgImage = (SvgImage)image;

                var rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = svgImage.Size;

                var pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

                svgImage.Save(originalPath, pngOptions);
            }

            // Load rasterized image, apply motion blur, and save filtered PNG
            using (Image img = Image.Load(originalPath))
            {
                var rasterImage = (RasterImage)img;

                rasterImage.Filter(rasterImage.Bounds,
                    new MotionWienerFilterOptions(7, 1.0, 315.0));

                rasterImage.Save(filteredPath, new PngOptions());
            }

            // Simple comparison of the two raster images
            using (Image origImg = Image.Load(originalPath))
            using (Image filtImg = Image.Load(filteredPath))
            {
                var origRaster = (RasterImage)origImg;
                var filtRaster = (RasterImage)filtImg;

                bool areEqual = true;

                if (origRaster.Width != filtRaster.Width || origRaster.Height != filtRaster.Height)
                {
                    areEqual = false;
                }
                else
                {
                    int[] origPixels = origRaster.LoadArgb32Pixels(origRaster.Bounds);
                    int[] filtPixels = filtRaster.LoadArgb32Pixels(filtRaster.Bounds);

                    for (int i = 0; i < origPixels.Length; i++)
                    {
                        if (origPixels[i] != filtPixels[i])
                        {
                            areEqual = false;
                            break;
                        }
                    }
                }

                Console.WriteLine(areEqual ? "Images are identical." : "Images differ.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a PNG preview from an SVG file and then add a motion blur effect for visual styling in a C# application.
 * 2. When you want to programmatically compare the original rasterized SVG with a blurred version to detect visual differences or perform regression testing.
 * 3. When creating thumbnail images from vector graphics and applying motion blur to simulate movement in a game UI or multimedia project.
 * 4. When automating batch processing of SVG assets to produce blurred PNG files for marketing banners or social media posts using Aspose.Imaging.
 * 5. When validating that a motion blur filter preserves image dimensions and can be consistently applied across multiple SVG files in a backend image‑processing service.
 */
