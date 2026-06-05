using System;
using System.IO;
using System.Collections.Generic;
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
            string inputPath = "input.djvu";
            string outputPdfPath = "merged.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            string[] pngPaths = new string[3];
            for (int i = 0; i < 3; i++)
            {
                pngPaths[i] = $"page{i + 2}.png";
                Directory.CreateDirectory(Path.GetDirectoryName(pngPaths[i]));
            }

            using (DjvuImage djvu = (DjvuImage)Aspose.Imaging.Image.Load(inputPath))
            {
                for (int i = 0; i < 3; i++)
                {
                    int pageIndex = i + 1; // pages 2‑4 (0‑based)
                    using (DjvuPage page = (DjvuPage)djvu.Pages[pageIndex])
                    {
                        Source pngSource = new FileCreateSource(pngPaths[i], false);
                        PngOptions pngOptions = new PngOptions() { Source = pngSource };
                        page.Save(pngPaths[i], pngOptions);
                    }
                }
            }

            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string pngPath in pngPaths)
            {
                using (RasterImage img = (RasterImage)Aspose.Imaging.Image.Load(pngPath))
                {
                    sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
                }
            }

            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (var sz in sizes)
            {
                if (sz.Width > canvasWidth) canvasWidth = sz.Width;
                canvasHeight += sz.Height;
            }

            using (RasterImage canvas = (RasterImage)Aspose.Imaging.Image.Create(new PngOptions(), canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string pngPath in pngPaths)
                {
                    using (RasterImage img = (RasterImage)Aspose.Imaging.Image.Load(pngPath))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                Source pdfSource = new FileCreateSource(outputPdfPath, false);
                PdfOptions pdfOptions = new PdfOptions() { Source = pdfSource };
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
 * 1. When a developer needs to extract specific pages (2‑4) from a multi‑page DjVu document, convert them to high‑quality PNG images, and then combine those images into a single PDF report for distribution.
 * 2. When an archival system must transform selected DjVu pages into PNG thumbnails for preview and later bundle them into a PDF portfolio for client review.
 * 3. When a document‑processing pipeline requires converting a range of DjVu pages to raster PNG files to apply image‑based analysis before merging the results into a consolidated PDF file.
 * 4. When a web application wants to let users download a PDF that contains only the chosen pages of a DjVu e‑book, using C# and Aspose.Imaging to render those pages as PNG and assemble the final PDF.
 * 5. When a batch job automates the conversion of specific DjVu pages into PNG assets for printing and then creates a printable PDF booklet from those assets using Aspose.Imaging’s image and PDF options.
 */