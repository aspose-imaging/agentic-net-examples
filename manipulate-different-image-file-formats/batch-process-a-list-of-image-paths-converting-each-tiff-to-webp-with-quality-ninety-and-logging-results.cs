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
            // Hardcoded list of TIFF files to process
            string[] inputPaths = new string[]
            {
                @"C:\Images\image1.tif",
                @"C:\Images\image2.tif",
                @"C:\Images\image3.tif"
            };

            // Hardcoded output directory for WebP files
            string outputDirectory = @"C:\Images\WebP";

            foreach (var inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with .webp extension
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image and save as WebP with quality 90
                using (Image image = Image.Load(inputPath))
                {
                    var webpOptions = new WebPOptions
                    {
                        Quality = 90
                    };
                    image.Save(outputPath, webpOptions);
                }

                // Log successful conversion
                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}