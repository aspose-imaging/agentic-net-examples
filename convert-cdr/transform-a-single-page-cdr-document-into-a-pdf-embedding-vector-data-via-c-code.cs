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
            string outputPath = @"C:\Data\sample_page0.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int pageNumber = 0;

            // Load the CDR image
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Get the specified page
                CdrImagePage imagePage = (CdrImagePage)image.Pages[pageNumber];

                // Configure PDF export options with vector rasterization
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = imagePage.Width,
                    PageHeight = imagePage.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the page as PDF
                imagePage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}