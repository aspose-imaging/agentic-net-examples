// HOW-TO: Convert DjVu Pages 2 To 4 To PNG And Merge Into PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDjvuPath = "input.djvu";
            string outputFolder = "output";
            string pngFolder = Path.Combine(outputFolder, "pngs");
            string pdfPath = Path.Combine(outputFolder, "merged.pdf");

            if (!File.Exists(inputDjvuPath))
            {
                Console.Error.WriteLine($"File not found: {inputDjvuPath}");
                return;
            }

            Directory.CreateDirectory(pngFolder);
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            List<string> pngPaths = new List<string>();

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputDjvuPath))
            {
                int startPage = 1; // page index 1 = page 2
                int endPage = 3;   // page index 3 = page 4

                for (int i = startPage; i <= endPage && i < djvu.Pages.Length; i++)
                {
                    string pngPath = Path.Combine(pngFolder, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

                    PngOptions pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(pngPath, false)
                    };

                    djvu.Pages[i].Save(pngPath, pngOptions);
                    pngPaths.Add(pngPath);
                }
            }

            // Load PNGs to calculate canvas size
            List<RasterImage> pngImages = new List<RasterImage>();
            int canvasWidth = 0;
            int canvasHeight = 0;

            foreach (string pngPath in pngPaths)
            {
                if (!File.Exists(pngPath))
                {
                    Console.Error.WriteLine($"File not found: {pngPath}");
                    return;
                }

                RasterImage img = (RasterImage)Image.Load(pngPath);
                pngImages.Add(img);
                canvasWidth = Math.Max(canvasWidth, img.Width);
                canvasHeight += img.Height;
            }

            // Create canvas
            PngOptions canvasOptions = new PngOptions();
            using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (RasterImage img in pngImages)
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                    img.Dispose();
                }

                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(pdfPath, pdfOptions);
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
 * 1. When you need to extract specific pages from a DjVu document and save them as high‑quality PNG images for web preview or further editing.
 * 2. When you want to create a PDF that contains only selected pages of a multi‑page DjVu file, such as a subset of a scanned book.
 * 3. When an application must automate the conversion of DjVu pages to PNG before applying image‑processing algorithms like OCR or watermarking.
 * 4. When you need to generate a printable PDF from a range of DjVu pages while preserving the original resolution of each page.
 * 5. When a workflow requires batch processing of DjVu files, converting chosen pages to PNG and then combining them into a single PDF report.
 */
