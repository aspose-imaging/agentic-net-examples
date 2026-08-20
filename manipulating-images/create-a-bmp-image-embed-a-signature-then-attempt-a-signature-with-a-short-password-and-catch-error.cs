// HOW-TO: Create BMP Image, Embed Digital Signature, Handle Invalid Password in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\Temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new 100x100 BMP image with 24 bits per pixel
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            using (RasterImage image = (RasterImage)Image.Create(bmpOptions, 100, 100))
            {
                // Fill the image with a solid color (white)
                image.Save(); // initial save to create the file

                // Embed a digital signature using a valid password
                image.EmbedDigitalSignature("StrongPassword123!");

                // Save the signed image
                image.Save(outputPath);
            }

            // Load the signed image to attempt a second embedding with a short password
            using (RasterImage signedImage = (RasterImage)Image.Load(outputPath))
            {
                try
                {
                    // This should trigger a DigitalSignatureException due to an insufficient password
                    signedImage.EmbedDigitalSignature("12");
                    signedImage.Save(outputPath);
                }
                catch (DigitalSignatureException dse)
                {
                    Console.Error.WriteLine($"DigitalSignatureException caught: {dse.Message}");
                }
                catch (ImageException ie)
                {
                    Console.Error.WriteLine($"ImageException caught: {ie.Message}");
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
 * 1. When you need to generate a blank BMP file and protect it with a digital signature for tamper detection.
 * 2. When you want to embed a secure signature into an image using a strong password before distributing it.
 * 3. When you must verify that a short or weak password is rejected by the Aspose.Imaging digital signature API.
 * 4. When you are building an automated workflow that creates, signs, and validates images on a server file system.
 * 5. When you need to catch and log specific DigitalSignatureException errors while processing signed images in a .NET application.
 */
