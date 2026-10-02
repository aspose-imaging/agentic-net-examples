// HOW-TO: Combine Multiple JPEG Images Horizontally and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
            string[] inputPaths = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "merged.pdf";

            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<int> widths = new List<int>();
            List<int> heights = new List<int>();
            foreach (string path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    widths.Add(img.Width);
                    heights.Add(img.Height);
                }
            }

            int totalWidth = widths.Sum();
            int maxHeight = heights.Max();

            string tempJpegPath = "temp_canvas.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(tempJpegPath));
            FileCreateSource tempSource = new FileCreateSource(tempJpegPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPath, pdfOptions);
            }

            if (File.Exists(tempJpegPath))
            {
                try { File.Delete(tempJpegPath); } catch { }
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
 * 1. When you need to create a single PDF catalog page by stitching product photos stored as JPEGs side‑by‑side.
 * 2. When generating a printable PDF report that combines scanned receipt images into one horizontal strip.
 * 3. When building a web service that receives multiple JPEG uploads and returns a merged PDF for easy download.
 * 4. When automating the creation of a PDF brochure where landscape images must appear in a continuous horizontal layout.
 * 5. When consolidating security camera snapshots taken at the same moment into a single PDF document for quick review.
 */
