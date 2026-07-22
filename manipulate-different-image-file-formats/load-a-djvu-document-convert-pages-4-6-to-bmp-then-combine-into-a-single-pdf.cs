using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.djvu";
            string outputBmpDir = "bmp_pages";
            string outputPdfPath = "combined.pdf";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(outputBmpDir);
            string pdfDir = Path.GetDirectoryName(outputPdfPath);
            if (!string.IsNullOrWhiteSpace(pdfDir))
            {
                Directory.CreateDirectory(pdfDir);
            }

            // Load DjVu document
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Pages 4‑6 (zero‑based indexes 3,4,5)
                int[] pageIndexes = { 3, 4, 5 };
                string[] bmpPaths = new string[pageIndexes.Length];

                for (int i = 0; i < pageIndexes.Length; i++)
                {
                    int idx = pageIndexes[i];
                    if (idx < 0 || idx >= djvuImage.PageCount)
                    {
                        Console.Error.WriteLine($"Page index out of range: {idx + 1}");
                        return;
                    }

                    string bmpPath = Path.Combine(outputBmpDir, $"page_{idx + 1}.bmp");
                    bmpPaths[i] = bmpPath;

                    // Save each selected page as BMP
                    djvuImage.Pages[idx].Save(bmpPath, new BmpOptions());
                }

                // Load BMP images into memory
                Image[] bmpImages = new Image[bmpPaths.Length];
                for (int i = 0; i < bmpPaths.Length; i++)
                {
                    bmpImages[i] = Image.Load(bmpPaths[i]);
                }

                // Combine BMPs into a single multi‑page image
                using (Image combined = Image.Create(bmpImages, true))
                {
                    // Save combined image as PDF
                    combined.Save(outputPdfPath, new PdfOptions());
                }

                // Dispose loaded BMP images
                foreach (var img in bmpImages)
                {
                    img.Dispose();
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
 * 1. When a developer needs to extract specific pages (4‑6) from a multi‑page DjVu file and provide them as high‑resolution BMP images for further image‑processing or OCR workflows.
 * 2. When an application must convert selected DjVu pages into BMP format to preserve lossless pixel data before merging them into a single PDF for easy distribution to users who cannot view DjVu.
 * 3. When a legal or archival system requires converting scanned DjVu documents into BMP thumbnails and then bundling those pages into a PDF report for compliance review.
 * 4. When a publishing tool automates the creation of a PDF booklet that contains only certain DjVu pages, using Aspose.Imaging for .NET to render those pages as BMP before PDF assembly.
 * 5. When a developer builds a batch‑processing service that extracts pages 4‑6 from many DjVu files, saves them as BMP files for quality control, and then combines the BMPs into one PDF for archival storage.
 */