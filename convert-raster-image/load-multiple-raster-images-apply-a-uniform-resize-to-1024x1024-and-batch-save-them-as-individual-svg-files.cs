using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input files and output directory
            string[] inputFiles = new[]
            {
                @"C:\Images\image1.png",
                @"C:\Images\image2.jpg",
                @"C:\Images\image3.bmp"
            };
            string outputDirectory = @"C:\Images\SvgOutput";

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output SVG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load, resize, and save as SVG
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to 1024x1024
                    image.Resize(1024, 1024);

                    // Prepare SVG save options with rasterization settings
                    var svgOptions = new SvgOptions();
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size // Set page size to match resized image
                    };
                    svgOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the image as SVG
                    image.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}