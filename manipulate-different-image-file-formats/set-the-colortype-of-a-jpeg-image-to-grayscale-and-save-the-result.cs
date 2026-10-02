// HOW-TO: Convert JPEG Image To Grayscale And Save With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/source.jpg";
            string outputPath = "Output/grayscale.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                image.Grayscale();

                using (JpegOptions options = new JpegOptions())
                {
                    image.Save(outputPath, options);
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
 * 1. When you need to generate black‑and‑white previews of user‑uploaded JPEG photos for a web gallery.
 * 2. When you must reduce the file size of JPEG images for email attachments by converting them to grayscale.
 * 3. When preparing scanned color JPEG documents for OCR, converting them to a single‑channel grayscale improves recognition accuracy.
 * 4. When creating print‑ready assets that require a single‑channel image to meet publishing specifications.
 * 5. When standardizing a batch of product JPEG images to grayscale before uploading them to an e‑commerce platform.
 */
