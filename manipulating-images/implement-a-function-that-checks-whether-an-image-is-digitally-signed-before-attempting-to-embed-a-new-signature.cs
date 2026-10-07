// HOW-TO: Check and Embed Digital Signature in an Image Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

namespace ImageSignatureDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths and password
                string inputPath = "input.jpg";
                string outputPath = "output.png";
                string password = "mySecret";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image as RasterImage
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Check if the image is already digitally signed with the given password
                    if (image.IsDigitalSigned(password))
                    {
                        Console.WriteLine("Image is already digitally signed with the provided password.");
                    }
                    else
                    {
                        // Embed digital signature
                        image.EmbedDigitalSignature(password);
                        // Save the signed image
                        image.Save(outputPath);
                        Console.WriteLine($"Digital signature embedded and image saved to {outputPath}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to verify that a JPEG file is already signed before converting it to a PNG to avoid duplicate signatures.
 * 2. When your application must ensure a confidential image is protected with a password‑based digital signature before distribution.
 * 3. When processing user‑uploaded photos you want to embed a digital signature only if the image hasn't been signed previously.
 * 4. When automating a workflow that converts signed images to another format while preserving the original signature status.
 * 5. When integrating Aspose.Imaging in a C# service that validates and signs images to meet regulatory compliance requirements.
 */
