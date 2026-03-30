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
        // Hardcoded input and output directories
        string inputDir = @"C:\InputSvgs";
        string outputDir = @"C:\OutputSvgs";

        // Get all SVG files in the input directory
        string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");

        foreach (string inputPath in svgFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDir, fileNameWithoutExt + "_blur.png");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (var pngOptions = new PngOptions())
                {
                    pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = vectorImage.Size
                    };

                    using (var memoryStream = new MemoryStream())
                    {
                        vectorImage.Save(memoryStream, pngOptions);
                        memoryStream.Position = 0;

                        // Load rasterized image
                        using (Image rasterImageContainer = Image.Load(memoryStream))
                        {
                            RasterImage rasterImage = (RasterImage)rasterImageContainer;

                            // Apply Gaussian blur filter (radius 5, sigma 4.0)
                            rasterImage.Filter(rasterImage.Bounds,
                                new GaussianBlurFilterOptions(5, 4.0));

                            // Save the processed image
                            rasterImage.Save(outputPath);
                        }
                    }
                }
            }
        }
    }
}