using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\sample.cdr";
        string outputPath = @"C:\Data\output\sample_page0.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR image
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Select the first page (index 0)
            CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];

            // Configure PDF save options with vector rasterization settings
            PdfOptions pdfOptions = new PdfOptions();
            CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                PageWidth = page.Width,
                PageHeight = page.Height
            };
            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save the selected page as PDF
            page.Save(outputPath, pdfOptions);
        }
    }
}