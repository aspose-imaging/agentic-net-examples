using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\InputSvgs";
            string outputFolder = @"C:\Images\OutputSvgs";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output file path (same name with .png extension)
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Set up rasterization options to convert SVG to raster format
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Rasterize SVG into a memory stream
                    using (var ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load the rasterized image as a RasterImage
                        using (Image rasterImg = Image.Load(ms))
                        {
                            var raster = (RasterImage)rasterImg;

                            // Apply Gaussian blur with size 5 (odd) and sigma 2.0
                            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 2.0));

                            // Save the processed image
                            raster.Save(outputPath);
                        }
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