using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded paths and password
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";
        string password = "SharedPassword123";

        try
        {
            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_signed.png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, embed the digital signature, and save
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access EmbedDigitalSignature
                    if (image is RasterImage rasterImage)
                    {
                        rasterImage.EmbedDigitalSignature(password);
                        rasterImage.Save(outputPath);
                        Console.WriteLine($"Signed successfully: {inputPath} -> {outputPath}");
                    }
                    else
                    {
                        Console.Error.WriteLine($"Unsupported image type for file: {inputPath}");
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