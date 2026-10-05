// HOW-TO: Batch Embed Digital Signature into Large Images with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";
            string password = "MySecretPwd";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all files in the input folder
            string[] files = Directory.GetFiles(inputFolder);
            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load image
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Check minimum size requirements
                    if (image.Width < 8 || image.Height < 8 || (image.Width * image.Height) < 16384)
                    {
                        Console.WriteLine($"Skipping {Path.GetFileName(inputPath)}: does not meet size requirements.");
                        continue;
                    }

                    // Embed digital signature
                    image.EmbedDigitalSignature(password);

                    // Prepare output path
                    string outputPath = Path.Combine(outputFolder, Path.GetFileName(inputPath));

                    // Ensure directory for output path exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save image (preserving original format)
                    image.Save(outputPath);
                    Console.WriteLine($"Signed and saved: {outputPath}");
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
 * 1. When you need to protect high‑resolution product photos by adding a password‑protected digital signature before publishing them online.
 * 2. When a document management system must automatically sign only images that meet a minimum size threshold to avoid processing thumbnails.
 * 3. When a batch processing tool has to embed a digital signature into JPEG, PNG, or TIFF files while preserving their original format.
 * 4. When you want to ensure that only images larger than 128 × 128 pixels (or 16 384 total pixels) are signed to meet regulatory size requirements.
 * 5. When integrating Aspose.Imaging in a C# application to sign scanned contracts stored in a folder, skipping any small preview images.
 */
