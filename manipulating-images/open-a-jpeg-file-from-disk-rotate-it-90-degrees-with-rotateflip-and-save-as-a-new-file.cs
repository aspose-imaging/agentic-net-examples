// HOW-TO: Rotate a JPEG 90 Degrees and Save New File in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output/rotated.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When you need to automatically correct portrait‑oriented photos uploaded by users before storing them on the server.
 * 2. When generating thumbnails that must be displayed in landscape orientation for a web gallery.
 * 3. When preprocessing scanned documents that were saved sideways and must be rotated for OCR processing.
 * 4. When creating a batch job that re‑orients product images to match a catalog layout without manual editing.
 * 5. When integrating a C# service that receives JPEGs from a mobile app and must rotate them 90° before saving to a cloud folder.
 */
