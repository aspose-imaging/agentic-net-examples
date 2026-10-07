// HOW-TO: Batch Apply Motion Blur to SVGs and Create Thumbnails in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputSvgs";
            string outputDirectory = "OutputSvgs";
            string thumbnailDirectory = "Thumbnails";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);
            Directory.CreateDirectory(thumbnailDirectory);

            var svgFiles = Directory.GetFiles(inputDirectory, "*.svg");
            foreach (var inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");
                string thumbPath = Path.Combine(thumbnailDirectory, fileName + "_thumb.png");

                // Load SVG
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Rasterize SVG to temporary PNG
                    string tempPng = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Color.White
                    };
                    var pngSaveOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };
                    svgImage.Save(tempPng, pngSaveOptions);

                    // Load rasterized image
                    using (RasterImage raster = (RasterImage)Image.Load(tempPng))
                    {
                        // Apply motion blur filter (size 3, angle 0)
                        double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(3, 0);
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);

                        // Save blurred image
                        raster.Save(outputPath, new PngOptions());

                        // Generate thumbnail (quarter size)
                        using (RasterImage thumb = (RasterImage)Image.Load(outputPath))
                        {
                            int thumbWidth = Math.Max(thumb.Width / 4, 1);
                            int thumbHeight = Math.Max(thumb.Height / 4, 1);
                            thumb.Resize(thumbWidth, thumbHeight);
                            thumb.Save(thumbPath, new PngOptions());
                        }
                    }

                    // Clean up temporary file
                    if (File.Exists(tempPng))
                    {
                        File.Delete(tempPng);
                    }
                }
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
 * 1. When you need to automatically add a motion‑blur effect to a collection of SVG icons before publishing them on a website.
 * 2. When you want to convert vector SVG assets to raster PNGs with a consistent blur style for use in a mobile app UI.
 * 3. When you must generate small preview images (thumbnails) of blurred SVG graphics for a digital asset management system.
 * 4. When you are building a batch processing pipeline that prepares SVG illustrations for PDF reports by applying blur and creating low‑resolution previews.
 * 5. When you need to script the transformation of design files into blurred PNGs and thumbnails for automated testing of visual effects.
 */
