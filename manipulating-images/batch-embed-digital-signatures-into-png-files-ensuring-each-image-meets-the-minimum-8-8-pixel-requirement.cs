using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";
        // Password used for digital signature
        string password = "mySecret";

        try
        {
            // Get all PNG files in the input folder
            string[] inputFiles = Directory.GetFiles(inputFolder, "*.png");

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load the image as a RasterImage (PNG is a raster format)
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Ensure the image meets the minimum size requirement
                    if (image.Width < 8 || image.Height < 8)
                    {
                        Console.Error.WriteLine($"Image too small (minimum 8x8): {inputPath}");
                        continue;
                    }

                    // Embed the digital signature using the provided password
                    image.EmbedDigitalSignature(password);

                    // Determine the output path (same file name in the output folder)
                    string outputPath = Path.Combine(outputFolder, Path.GetFileName(inputPath));

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the signed image
                    image.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}