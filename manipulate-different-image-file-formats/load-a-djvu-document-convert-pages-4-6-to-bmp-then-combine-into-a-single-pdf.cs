using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.djvu";
            string outputPdfPath = "combined.pdf";
            string bmpOutputDir = "bmp_pages";

            // Ensure output directories
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));
            Directory.CreateDirectory(bmpOutputDir);

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load DjVu document
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Pages 4‑6 (zero‑based indexes 3,4,5)
                int[] pageIndexes = new int[] { 3, 4, 5 };

                // Save each selected page as BMP
                for (int i = 0; i < pageIndexes.Length; i++)
                {
                    int idx = pageIndexes[i];
                    if (idx < 0 || idx >= djvuImage.PageCount)
                        continue;

                    string bmpPath = Path.Combine(bmpOutputDir, $"page{idx + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));

                    BmpOptions bmpOptions = new BmpOptions();
                    djvuImage.Pages[idx].Save(bmpPath, bmpOptions);
                }

                // Combine selected pages into a single PDF
                Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));
                PdfOptions pdfOptions = new PdfOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(pageIndexes)
                };
                djvuImage.Save(outputPdfPath, pdfOptions);
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
 * 1. When a developer needs to extract specific pages (e.g., pages 4‑6) from a DjVu document and save them as high‑resolution BMP images for further image‑processing or OCR tasks.
 * 2. When a legacy workflow requires converting selected DjVu pages into BMP files to be used as thumbnails or preview images in a Windows desktop application.
 * 3. When an archival system must combine a subset of DjVu pages into a single PDF file for easier distribution or printing while preserving the original page order.
 * 4. When a document‑management solution needs to programmatically validate the existence of a DjVu file, extract particular pages, and generate both BMP assets and a consolidated PDF in one automated step.
 * 5. When a C# service integrates Aspose.Imaging to batch‑process DjVu files, converting chosen pages to BMP for image analysis and then merging those pages into a PDF report for end‑users.
 */