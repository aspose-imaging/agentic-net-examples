// HOW-TO: Rotate TIFF Image 90 Degrees Clockwise and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "Input\\image.tif";
                string outputPath = "Output\\rotated.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        image.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging system receives scanned TIFF files that need to be re‑oriented for display in a Windows application that only supports BMP format.
 * 2. When a batch job must convert legacy TIFF maps into BMP thumbnails after rotating them to match the north‑up orientation.
 * 3. When a document workflow requires rotating incoming TIFF invoices 90° clockwise before archiving them as BMP for compatibility with older reporting tools.
 * 4. When a game asset pipeline needs to take high‑resolution TIFF textures, rotate them, and store them as BMP for fast loading in the engine.
 * 5. When an automated script processes scanned forms, rotates each page, and saves the result as BMP to be consumed by a third‑party OCR service that only accepts BMP input.
 */
