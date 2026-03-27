using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded list of TIFF input files
        string[] inputPaths = new string[]
        {
            @"C:\Images\Input1.tif",
            @"C:\Images\Input2.tif",
            @"C:\Images\Input3.tif"
        };

        // Hardcoded output directory
        string outputDirectory = @"C:\Images\WebPOutput";

        // Ensure the output directory exists (unconditional as per rule)
        Directory.CreateDirectory(outputDirectory);

        foreach (string inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output path with .webp extension
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure the output directory exists (unconditional as per rule)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            try
            {
                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Set WebP options with quality 90
                    var webpOptions = new WebPOptions
                    {
                        Quality = 90
                    };

                    // Save as WebP
                    image.Save(outputPath, webpOptions);
                }

                Console.WriteLine($"Successfully converted '{inputPath}' to '{outputPath}'.");
            }
            catch (Exception ex)
            {
                // Log any conversion errors without throwing
                Console.Error.WriteLine($"Error processing '{inputPath}': {ex.Message}");
            }
        }
    }
}