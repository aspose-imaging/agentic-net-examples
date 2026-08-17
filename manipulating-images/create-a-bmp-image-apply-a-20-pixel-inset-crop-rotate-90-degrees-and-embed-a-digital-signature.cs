// HOW-TO: Create BMP Image, Crop Inset, Rotate 90 Degrees, Embed Digital Signature in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";

        try
        {
            // Create a BMP image with minimum size for digital signature (200x200)
            using (BmpImage bmp = new BmpImage(200, 200))
            {
                // Fill the image with white color
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        bmp.SetPixel(x, y, Color.White);
                    }
                }

                // Apply a 20-pixel inset crop (left, right, top, bottom)
                bmp.Crop(20, 20, 20, 20);

                // Rotate the image 90 degrees clockwise
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Embed a digital signature with a valid password
                bmp.EmbedDigitalSignature("secure123");

                // Ensure the output directory exists
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Save the processed image
                bmp.Save(outputPath);
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
 * 1. When you need to generate a blank BMP canvas and embed a password‑protected digital signature using Aspose.Imaging in C#.
 * 2. When you must apply a 20‑pixel inset crop to a BMP before rotating it for a consistent layout in a reporting system.
 * 3. When an application requires a 90‑degree clockwise rotation of a cropped BMP to match printer orientation.
 * 4. When you want to create a small (200×200) signature image that can be validated later with a digital signature.
 * 5. When you need to automate batch processing of BMP files that include cropping, rotation, and embedded signatures in a C# workflow.
 */
