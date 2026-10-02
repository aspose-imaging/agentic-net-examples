// HOW-TO: Create BMP Crop Inset Rotate 90° and Add Digital Signature in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a BMP image if it does not exist
            if (!File.Exists(inputPath))
            {
                int width = 200;
                int height = 200;
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24
                };
                using (RasterImage image = (RasterImage)Image.Create(bmpOptions, width, height))
                {
                    // Fill with white background
                    image.Save(inputPath);
                }
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Apply a 20-pixel inset crop
                image.Crop(20, 20, 20, 20);

                // Rotate 90 degrees clockwise
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Embed digital signature with a password
                string password = "pass1234";
                image.EmbedDigitalSignature(password);

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When you need to generate a blank BMP file, crop a border, rotate it, and protect it with a password‑protected digital signature for secure document workflows.
 * 2. When an application must preprocess scanned forms by trimming edges, aligning orientation, and embedding a signature to verify authenticity before archival.
 * 3. When a reporting tool creates chart images in BMP, requires a uniform 20‑pixel margin removal, rotates the chart for landscape layout, and signs the file to prevent tampering.
 * 4. When a batch job prepares product label images, crops unnecessary whitespace, rotates them to match printing direction, and adds a digital signature to comply with regulatory traceability.
 * 5. When a security‑focused system needs to programmatically create a placeholder BMP, apply geometric transformations, and embed a password‑protected signature for later validation.
 */
