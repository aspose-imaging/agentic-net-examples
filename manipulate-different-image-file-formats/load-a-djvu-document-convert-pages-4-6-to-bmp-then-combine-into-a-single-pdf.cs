// HOW-TO: Convert DjVu Pages 4 To 6 To BMP And Merge Into PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.djvu";
            string outputDir = "output";
            string[] bmpPaths = {
                Path.Combine(outputDir, "page4.bmp"),
                Path.Combine(outputDir, "page5.bmp"),
                Path.Combine(outputDir, "page6.bmp")
            };
            string pdfPath = Path.Combine(outputDir, "combined.pdf");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load DjVu document and export pages 4‑6 as BMP
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvu = new DjvuImage(stream))
            {
                int[] pageIndices = { 3, 4, 5 }; // zero‑based indices for pages 4‑6
                for (int i = 0; i < pageIndices.Length; i++)
                {
                    DjvuPage page = (DjvuPage)djvu.Pages[pageIndices[i]];
                    page.Save(bmpPaths[i], new BmpOptions());
                }
            }

            // Load BMP images
            List<Image> bmpImages = new List<Image>();
            foreach (var bmpPath in bmpPaths)
            {
                if (!File.Exists(bmpPath))
                {
                    Console.Error.WriteLine($"File not found: {bmpPath}");
                    foreach (var img in bmpImages) img.Dispose();
                    return;
                }
                bmpImages.Add(Image.Load(bmpPath));
            }

            // Combine BMPs into a single PDF
            using (Image pdf = Image.Create(bmpImages.ToArray(), true))
            {
                pdf.Save(pdfPath, new PdfOptions());
            }

            // Dispose loaded BMP images
            foreach (var img in bmpImages)
            {
                img.Dispose();
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
 * 1. When you need to extract specific pages from a multi‑page DjVu file and save them as high‑resolution BMP images for further processing or archival.
 * 2. When you must create a PDF that contains only selected pages of a DjVu document, such as pages 4‑6, for sharing with users who only have PDF viewers.
 * 3. When a workflow requires converting DjVu pages to a raster format before applying image‑based analysis or OCR tools that accept BMP input.
 * 4. When you are building a document‑conversion service that needs to split a DjVu file, generate intermediate bitmap files, and then combine them into a single PDF report.
 * 5. When you need to automate batch processing of DjVu files, extracting particular pages, converting them to BMP, and packaging them into PDFs for compliance or record‑keeping purposes.
 */
