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
            // Hardcoded list of TIFF input files
            string[] inputPaths = new string[]
            {
                @"C:\Images\sample1.tif",
                @"C:\Images\sample2.tif"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Images\WebPOutput";

            foreach (var inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with .webp extension
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure WebP options with quality 90
                    var webpOptions = new WebPOptions
                    {
                        Quality = 90
                    };

                    // Save as WebP
                    image.Save(outputPath, webpOptions);
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}