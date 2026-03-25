using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input CDR file path
        string inputPath = @"C:\temp\sample.cdr";

        // Hardcoded output directory for PDF pages
        string outputDir = @"C:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the multi‑page CDR image
        using (CdrImage image = (CdrImage)Image.Load(inputPath))
        {
            // Cache all pages to avoid repeated data loading
            foreach (CdrImagePage page in image.Pages)
            {
                page.CacheData();
            }

            // Iterate through each page and save as an individual PDF
            for (int i = 0; i < image.Pages.Length; i++)
            {
                CdrImagePage page = (CdrImagePage)image.Pages[i];
                string outputPath = Path.Combine(outputDir, $"page_{i}.pdf");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure PDF options with rasterization settings matching the page size
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = page.Width,
                    PageHeight = page.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the current page as a PDF file
                page.Save(outputPath, pdfOptions);
            }
        }
    }
}