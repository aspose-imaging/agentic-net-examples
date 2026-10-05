// HOW-TO: Create A4 PDF from Horizontally Merged JPEG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new string[] { "Input/image1.jpg", "Input/image2.jpg", "Input/image3.jpg" };
            string outputPath = "Output/merged.pdf";

            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            JpegOptions jpegOptions = new JpegOptions();
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.PageSize = new SizeF(595, 842); // A4 size in points
                canvas.Save(outputPath, pdfOptions);
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
 * 1. When you need to combine multiple product photos into a single A4‑sized PDF catalog page for printing or sharing.
 * 2. When generating a printable invoice that includes scanned JPEG receipts placed side‑by‑side on an A4 PDF.
 * 3. When creating a landscape brochure that stitches together several JPEG banners into one A4 PDF document.
 * 4. When automating the conversion of a series of camera‑shot images into a standardized A4 PDF report for compliance archives.
 * 5. When building a web service that merges user‑uploaded JPEG screenshots into an A4 PDF for easy download and offline viewing.
 */
