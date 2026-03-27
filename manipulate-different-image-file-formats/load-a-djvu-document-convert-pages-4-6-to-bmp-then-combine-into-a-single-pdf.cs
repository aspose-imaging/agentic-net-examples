using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu file
        string inputPath = "input.djvu";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Directory for temporary BMP files
        string bmpDirectory = "bmps";
        Directory.CreateDirectory(bmpDirectory);

        // Output PDF file
        string outputPdfPath = "combined.pdf";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // List to hold loaded BMP images
        List<Image> bmpImages = new List<Image>();

        // Load DjVu document
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvu = new DjvuImage(stream))
        {
            // Pages 4‑6 correspond to indices 3‑5 (zero‑based)
            for (int pageIndex = 3; pageIndex <= 5; pageIndex++)
            {
                // Ensure the page exists
                if (pageIndex < 0 || pageIndex >= djvu.Pages.Length)
                {
                    Console.Error.WriteLine($"Page index out of range: {pageIndex + 1}");
                    continue;
                }

                // Save current page as BMP
                string bmpPath = Path.Combine(bmpDirectory, $"page{pageIndex + 1}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));

                // Cast to DjvuPage and save
                DjvuPage djvuPage = (DjvuPage)djvu.Pages[pageIndex];
                djvuPage.Save(bmpPath, new BmpOptions());

                // Load saved BMP for PDF assembly
                Image bmpImage = Image.Load(bmpPath);
                bmpImages.Add(bmpImage);
            }
        }

        // Create PDF from BMP images
        using (Image pdf = Image.Create(bmpImages.ToArray(), true))
        {
            pdf.Save(outputPdfPath, new PdfOptions());
        }

        // Dispose loaded BMP images
        foreach (var img in bmpImages)
        {
            img.Dispose();
        }
    }
}