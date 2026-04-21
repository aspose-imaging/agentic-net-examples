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
        // Input DjVu file
        string inputPath = "sample.djvu";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Directory for temporary BMP files
        string bmpOutputDir = "bmp_pages";
        Directory.CreateDirectory(bmpOutputDir);

        // List to hold loaded BMP images
        var bmpImages = new List<Image>();

        // Load DjVu document
        using (FileStream stream = File.OpenRead(inputPath))
        {
            using (DjvuImage djvu = new DjvuImage(stream))
            {
                // Zero‑based indexes for pages 4‑6
                int[] pageIndexes = new int[] { 3, 4, 5 };
                foreach (int idx in pageIndexes)
                {
                    if (idx < 0 || idx >= djvu.PageCount)
                        continue; // Skip invalid indexes

                    string bmpPath = Path.Combine(bmpOutputDir, $"page_{idx + 1}.bmp");
                    // Ensure the directory for the BMP exists (already created above)
                    djvu.Pages[idx].Save(bmpPath, new BmpOptions());

                    // Load the saved BMP for PDF creation
                    Image bmpImg = Image.Load(bmpPath);
                    bmpImages.Add(bmpImg);
                }
            }
        }

        // Combine BMP pages into a single PDF
        if (bmpImages.Count > 0)
        {
            string pdfOutputPath = "combined.pdf";
            string pdfDir = Path.GetDirectoryName(pdfOutputPath);
            if (!string.IsNullOrWhiteSpace(pdfDir))
                Directory.CreateDirectory(pdfDir);

            using (Image pdf = Image.Create(bmpImages.ToArray(), true))
            {
                pdf.Save(pdfOutputPath, new PdfOptions());
            }
        }

        // Dispose loaded BMP images
        foreach (var img in bmpImages)
        {
            img.Dispose();
        }
    }
}