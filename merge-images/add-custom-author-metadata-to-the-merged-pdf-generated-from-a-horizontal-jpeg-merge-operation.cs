// HOW-TO: Add Author Metadata to Merged Horizontal JPEG PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
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
            string[] inputPaths = new string[] { "input1.jpg", "input2.jpg" };
            string outputPath = "merged.pdf";

            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            int newWidth = 0;
            int newHeight = 0;
            foreach (Size sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            string tempCanvasPath = Path.Combine(Path.GetTempPath(), "temp_canvas.jpg");
            string tempDir = Path.GetDirectoryName(tempCanvasPath);
            if (!string.IsNullOrEmpty(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }

            Source tempSource = new FileCreateSource(tempCanvasPath, true);
            JpegOptions canvasOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(canvasOptions, newWidth, newHeight))
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
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                pdfOptions.PdfDocumentInfo.Author = "Custom Author";

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
 * 1. When you need to combine multiple landscape-oriented JPEG photos into a single PDF report and embed the author's name for document tracking.
 * 2. When an automated invoice system must stitch product images side-by-side and produce a PDF with author metadata for compliance auditing.
 * 3. When a digital archive workflow requires creating a PDF from horizontally merged scanned pages while preserving author information for searchability.
 * 4. When a web application generates a portfolio PDF from user-uploaded JPEGs and wants to set the author field to credit the creator.
 * 5. When a batch processing script merges marketing banner images into one PDF and adds custom author metadata to satisfy branding guidelines.
 */
