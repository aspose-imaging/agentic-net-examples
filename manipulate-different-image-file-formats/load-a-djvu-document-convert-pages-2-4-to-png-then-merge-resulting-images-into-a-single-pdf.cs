// HOW-TO: Extract DjVu Pages 2 to 4 as PNG and Merge into PDF Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPdfPath = "output.pdf";
            string tempCanvasPath = "temp_canvas.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));

            // Step 1: Extract pages 2‑4 as PNG files
            List<string> pngPaths = new List<string>();
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvu = new DjvuImage(stream))
            {
                foreach (DjvuPage page in djvu.Pages)
                {
                    if (page.PageNumber >= 2 && page.PageNumber <= 4)
                    {
                        string pngPath = $"page_{page.PageNumber}.png";
                        FileCreateSource pngSource = new FileCreateSource(pngPath, false);
                        PngOptions pngOptions = new PngOptions { Source = pngSource };
                        page.Save(pngPath, pngOptions);
                        pngPaths.Add(pngPath);
                    }
                }
            }

            if (pngPaths.Count == 0)
            {
                Console.Error.WriteLine("No pages were extracted.");
                return;
            }

            // Step 2: Collect sizes of PNG images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string pngPath in pngPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(pngPath))
                {
                    sizes.Add(img.Size);
                }
            }

            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Step 3: Create temporary canvas (JPEG) for merging
            FileCreateSource canvasSource = new FileCreateSource(tempCanvasPath, false);
            JpegOptions canvasOptions = new JpegOptions { Source = canvasSource, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(canvasOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string pngPath in pngPaths)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(pngPath))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Step 4: Save merged canvas as PDF
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
 * 1. When you need to convert specific pages of a DjVu document into high‑quality PNG images for further processing or archival.
 * 2. When you want to create a single PDF that contains only selected pages from a multi‑page DjVu file.
 * 3. When you must extract a range of pages from a scanned DjVu book and embed them in a PDF report.
 * 4. When you are building a workflow that transforms DjVu pages to PNG before applying image‑based analysis and then packaging the results into a PDF.
 * 5. When you need to automate the conversion of DjVu pages to PNG and combine them into a PDF for distribution to users who cannot view DjVu files.
 */
