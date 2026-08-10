// HOW-TO: Batch Embed Digital Signatures into PNG Images with Size Check in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";
        string password = "mySecretPassword";

        try
        {
            // Get all PNG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image as a RasterImage (PNG files are supported)
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

                    // Determine the output path and ensure the directory exists
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the signed image
                    image.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to add a tamper‑evident digital signature to a large collection of PNG assets before publishing them online.
 * 2. When a compliance workflow requires every PNG file to be signed with a password‑protected signature to verify authenticity.
 * 3. When an automated build process must ensure all product screenshots meet a minimum 8×8 pixel size and are digitally signed for traceability.
 * 4. When a document management system imports PNG files and you must embed a signature to prevent unauthorized modifications.
 * 5. When you are preparing PNG graphics for a secure API and need to batch sign them while validating that each image meets the minimum dimension requirement.
 */
