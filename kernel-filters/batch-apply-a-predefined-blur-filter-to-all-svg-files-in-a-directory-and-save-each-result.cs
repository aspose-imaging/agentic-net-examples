// HOW-TO: Batch Apply Gaussian Blur to All SVG Files in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "input_svgs";
            string outputDirectory = "output_svgs";

            Directory.CreateDirectory(outputDirectory);

            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");
            foreach (string inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string tempPngPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_temp.png");
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_blur.png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(inputPath))
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    svgImage.Save(tempPngPath, pngOptions);
                }

                using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
                {
                    var blurOptions = new GaussianBlurFilterOptions
                    {
                        Radius = 5,
                        Sigma = 2.0
                    };

                    raster.Filter(raster.Bounds, blurOptions);
                    raster.Save(outputPath);
                }

                // Optionally delete the temporary PNG
                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
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
 * 1. When you need to automatically soften vector graphics before publishing them on a website, you can batch blur all SVG assets with this code.
 * 2. When a design pipeline requires converting SVG icons to raster PNGs, applying a Gaussian blur, and saving the results for use in mobile apps, this script handles the whole process.
 * 3. When you want to create a consistent blurred background effect for a set of SVG illustrations in a marketing campaign, the code processes every file in a folder without manual editing.
 * 4. When generating preview thumbnails of SVG diagrams with a subtle blur to protect proprietary details, the program rasterizes, blurs, and stores the images automatically.
 * 5. When integrating image preprocessing into a CI/CD workflow to ensure all SVG assets meet a blur standard before deployment, this batch routine can be invoked as part of the build script.
 */
