using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\sample.rotated.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Store original dimensions
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                // Rotate 270 degrees clockwise without flipping
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);

                // Verify dimensions remain unchanged
                if (image.Width != originalWidth || image.Height != originalHeight)
                {
                    Console.WriteLine("Dimensions changed after rotation.");
                }
                else
                {
                    Console.WriteLine("Dimensions unchanged after rotation.");
                }

                // Save the rotated image
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
 * 1. When a developer needs to re‑orient scanned BMP documents by 270° for correct portrait display while ensuring the image size stays the same.
 * 2. When an automated batch job must rotate legacy BMP assets for a game’s sprite sheet without altering their pixel dimensions.
 * 3. When a Windows desktop application processes user‑uploaded BMP photos and must rotate them 270° clockwise before saving, while confirming the width and height remain unchanged.
 * 4. When a C# service generates printable BMP labels that require a 270° rotation to match printer orientation, and the code must verify that the label dimensions are preserved.
 * 5. When a migration script updates BMP files from an old system, applying a 270° RotateFlip operation and checking that the image dimensions are consistent for downstream processing.
 */