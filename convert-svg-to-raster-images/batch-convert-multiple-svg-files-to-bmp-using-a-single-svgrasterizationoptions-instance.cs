using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory and list of SVG files
            string inputDir = @"C:\Images\Input";
            string[] svgFiles = new[] { "image1.svg", "image2.svg", "image3.svg" };

            // Single instance of rasterization options reused for all conversions
            var rasterizationOptions = new SvgRasterizationOptions();

            // Hardcoded output directory
            string outputDir = @"C:\Images\Output";

            foreach (var fileName in svgFiles)
            {
                string inputPath = Path.Combine(inputDir, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Set page size based on the loaded image dimensions
                    rasterizationOptions.PageSize = svgImage.Size;

                    // Prepare BMP save options using the shared rasterization options
                    var bmpOptions = new BmpOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Build output path with .bmp extension
                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".bmp");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image as BMP
                    svgImage.Save(outputPath, bmpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}