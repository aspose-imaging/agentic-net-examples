// HOW-TO: Rotate A JPEG 90 Degrees Clockwise And Save With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output_rotated.jpg";

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

            // Load the JPEG image, rotate 90 degrees clockwise, and save
            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
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
 * 1. When an e‑commerce site needs to automatically correct portrait‑oriented product photos uploaded as JPEGs before displaying them online.
 * 2. When a desktop application must rotate scanned JPEG documents 90° clockwise to match the original page orientation.
 * 3. When a photo‑gallery service processes user‑uploaded JPEG images to ensure consistent landscape layout across thumbnails.
 * 4. When a batch‑processing script has to re‑orient a large number of JPEG files on a server without using external tools.
 * 5. When a mobile‑backend API receives JPEG images from devices and must rotate them server‑side before storing them in storage.
 */
