using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string tempPngPath = "temp.png";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageSize = new SizeF(svgImage.Width * 2, svgImage.Height * 2)
                };

                svgImage.Save(tempPngPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 1.0));

                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 95
                };

                raster.Save(outputPath, jpegOptions);
            }

            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When a developer needs to convert an SVG illustration to a high‑resolution JPEG for web or print while applying a tilt‑shift style blur using Aspose.Imaging for .NET in C#.
 * 2. When a C# desktop tool must upscale vector graphics, rasterize them to PNG, apply a Gaussian blur filter, and output a 95‑quality JPEG for marketing materials.
 * 3. When an e‑commerce platform requires automated processing of SVG product icons into blurred, high‑definition JPEG thumbnails for a modern UI.
 * 4. When a batch‑processing script has to read vector files, enlarge the canvas, add a stylized blur effect, and save the results as JPEGs for archival or publishing workflows.
 * 5. When a developer wants to demonstrate Aspose.Imaging’s vector‑to‑raster conversion, image filtering, and JPEG export capabilities in a C# code sample for documentation or training.
 */