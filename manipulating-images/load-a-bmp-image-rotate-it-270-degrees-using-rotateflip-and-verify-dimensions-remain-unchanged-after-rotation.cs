// HOW-TO: Rotate BMP Image 270 Degrees In C# Without Changing Dimensions (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\sample_rotated.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image, rotate, verify dimensions, and save
            using (Image image = Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                // Rotate 270 degrees clockwise without flipping
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);

                // Verify dimensions remain unchanged
                if (image.Width != originalWidth || image.Height != originalHeight)
                {
                    Console.Error.WriteLine("Dimensions changed after rotation.");
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
 * 1. When you need to display a BMP graphic in portrait orientation for a Windows desktop application while keeping the original pixel dimensions.
 * 2. When processing scanned documents that must be rotated 270° for correct reading but the layout size must stay the same for downstream layout engines.
 * 3. When generating thumbnails of BMP files for a web gallery and the source images are stored rotated, requiring a 270° rotation without altering width and height.
 * 4. When integrating legacy BMP assets into a game engine that expects images in a specific orientation but the engine relies on unchanged image dimensions.
 * 5. When automating batch image preparation for printing where BMP files need a 270° rotation and you must verify that the rotation does not affect the image's resolution.
 */
