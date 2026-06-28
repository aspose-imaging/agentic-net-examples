using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "sample.djvu");
            string bmpOutputDir = Path.Combine("Output", "BmpPages");
            string pdfOutputPath = Path.Combine("Output", "Combined.pdf");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(bmpOutputDir));
            Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));

            // Load DjVu document
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Pages to process (4‑6 => zero‑based indexes 3,4,5)
                int[] pageIndexes = new int[] { 3, 4, 5 };

                // Save each selected page as BMP
                foreach (int idx in pageIndexes)
                {
                    if (idx < 0 || idx >= djvuImage.PageCount)
                        continue; // skip invalid indexes

                    var page = djvuImage.Pages[idx];
                    string bmpPath = Path.Combine(bmpOutputDir, $"page{idx + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
                    page.Save(bmpPath, new BmpOptions());
                }

                // Combine selected pages into a single PDF
                var pdfOptions = new PdfOptions();
                pdfOptions.MultiPageOptions = new DjvuMultiPageOptions(pageIndexes);
                djvuImage.Save(pdfOutputPath, pdfOptions);
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
 * 1. When a legal firm needs to extract pages 4‑6 from a multi‑page DjVu case file, convert them to high‑resolution BMP images for forensic analysis, and then bundle those images into a single PDF for client delivery.
 * 2. When an e‑learning platform wants to reuse specific illustration pages from a DjVu textbook, generate BMP files for image‑editing tools, and create a combined PDF handout for students.
 * 3. When a publishing house must isolate selected pages of a DjVu manuscript, convert them to BMP to apply watermarking or color correction, and then produce a consolidated PDF proof for reviewers.
 * 4. When a government archive digitizes historical documents stored as DjVu, extracts pages 4‑6 as BMP for OCR preprocessing, and merges them into a searchable PDF for public access.
 * 5. When a medical imaging system receives scanned reports in DjVu format, extracts the diagnostic image pages, saves them as BMP for integration with analysis software, and compiles them into a single PDF report for clinicians.
 */