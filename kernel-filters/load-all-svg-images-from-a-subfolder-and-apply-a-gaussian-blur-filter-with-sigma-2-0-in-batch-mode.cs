using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\OutputSvgs";

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (PNG with same name)
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Rasterize SVG to PNG in memory
                    using (MemoryStream rasterStream = new MemoryStream())
                    {
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new SvgRasterizationOptions
                            {
                                PageSize = svgImage.Size
                            }
                        };
                        svgImage.Save(rasterStream, pngOptions);
                        rasterStream.Position = 0;

                        // Load rasterized image as RasterImage
                        using (Image rasterImageContainer = Image.Load(rasterStream))
                        {
                            RasterImage rasterImage = (RasterImage)rasterImageContainer;

                            // Apply Gaussian blur filter with radius 5 and sigma 2.0
                            rasterImage.Filter(rasterImage.Bounds,
                                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 2.0));

                            // Save the filtered image as PNG
                            rasterImage.Save(outputPath, new PngOptions());
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