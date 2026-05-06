using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\sample.cdr";
            string outputPath = @"C:\Data\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Log the number of pages (layers)
                Console.WriteLine($"Page count: {image.PageCount}");

                // Export the first page to PDF
                int pageNumber = 0;
                CdrImagePage page = (CdrImagePage)image.Pages[pageNumber];

                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions()
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;
                pdfOptions.VectorRasterizationOptions.PageWidth = page.Width;
                pdfOptions.VectorRasterizationOptions.PageHeight = page.Height;

                page.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}