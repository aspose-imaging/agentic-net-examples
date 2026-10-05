// HOW-TO: Merge JPEG Images Horizontally into a 300 DPI PDF in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] allFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
            List<string> jpegFiles = new List<string>();
            foreach (var f in allFiles)
            {
                string ext = Path.GetExtension(f).ToLowerInvariant();
                if (ext == ".jpg" || ext == ".jpeg")
                {
                    jpegFiles.Add(f);
                }
            }

            if (jpegFiles.Count == 0)
            {
                Console.WriteLine("No JPEG files found.");
                return;
            }

            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (var path in jpegFiles)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            int totalWidth = 0;
            int maxHeight = 0;
            foreach (var sz in sizes)
            {
                totalWidth += sz.Width;
                if (sz.Height > maxHeight)
                    maxHeight = sz.Height;
            }

            string tempCanvasPath = Path.Combine(outputDirectory, "temp_canvas.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));

            Source source = new FileCreateSource(tempCanvasPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                canvas.HorizontalResolution = 300;
                canvas.VerticalResolution = 300;

                int offsetX = 0;
                foreach (var path in jpegFiles)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                string outputPdfPath = Path.Combine(outputDirectory, "merged.pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPdfPath, pdfOptions);
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
 * 1. When you need to combine multiple scanned photos side‑by‑side into a single high‑resolution PDF for printing or archiving.
 * 2. When generating a printable product catalog page by stitching product JPEG images horizontally and exporting to a 300 DPI PDF.
 * 3. When creating a side‑by‑side comparison document of before‑and‑after JPEG images for a client report in PDF format.
 * 4. When automating the preparation of large‑format advertisement layouts by merging banner JPEGs into a PDF with print‑ready DPI.
 * 5. When building a batch process that consolidates daily camera JPEG captures into a single PDF for easy distribution to stakeholders.
 */
