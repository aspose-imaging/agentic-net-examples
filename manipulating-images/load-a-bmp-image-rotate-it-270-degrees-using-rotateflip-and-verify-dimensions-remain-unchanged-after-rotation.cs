using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output_rotated.bmp";

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
                    Console.Error.WriteLine("Error: Image dimensions changed after rotation.");
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
 * 1. When a developer needs to rotate a BMP file 270 degrees for display in a legacy Windows application while keeping the original pixel dimensions unchanged.
 * 2. When an automated batch‑processing tool must re‑orient scanned BMP documents without altering their layout size before archiving.
 * 3. When a C# service integrates Aspose.Imaging to correct the orientation of user‑uploaded BMP images for a web portal while preserving the original width and height for UI consistency.
 * 4. When a desktop utility validates that a rotation operation does not distort image dimensions, ensuring that downstream GIS or CAD software receives correctly sized BMP files.
 * 5. When a quality‑assurance script checks that the RotateFlip method works on BMP images and that the saved output retains the same dimensions for pixel‑perfect printing.
 */