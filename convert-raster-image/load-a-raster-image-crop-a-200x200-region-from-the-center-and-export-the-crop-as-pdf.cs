// HOW-TO: Crop Center 200x200 Region from PNG and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.png");
            string outputPath = Path.Combine("Output", "cropped.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int cropWidth = 200;
                int cropHeight = 200;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;

                var cropRect = new Rectangle(left, top, cropWidth, cropHeight);
                image.Crop(cropRect);

                image.Save(outputPath, new PdfOptions());
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
 * 1. When you need to extract a square thumbnail from the middle of a product photo and deliver it as a PDF brochure.
 * 2. When generating a printable PDF preview of a specific area of a scanned document for legal review.
 * 3. When creating a centered cut‑out of a screenshot to embed in a report that must be distributed as PDF.
 * 4. When automating the preparation of a fixed‑size image patch for a machine‑learning dataset and storing it in PDF format.
 * 5. When converting a portion of a large PNG map into a compact PDF for offline viewing on mobile devices.
 */
