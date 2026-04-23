using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\sample.cdr";
        string outputPath = @"C:\Data\sample.pdf";

        try
        {
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
                // Retrieve and log the number of pages (layers)
                int pageCount = image.PageCount;
                Console.WriteLine($"Page count (layers): {pageCount}");

                // Export the first page to PDF
                if (pageCount > 0)
                {
                    CdrImagePage page = (CdrImagePage)image.Pages[0];

                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        PageWidth = page.Width,
                        PageHeight = page.Height
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    page.Save(outputPath, pdfOptions);
                    Console.WriteLine($"Exported page 0 to PDF: {outputPath}");
                }
                else
                {
                    Console.Error.WriteLine("No pages found in the CDR document.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}