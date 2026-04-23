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

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Configure rasterization to render text as vector shapes
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Set page size based on the first page of the CDR document
                if (image is CdrImage cdrImage && cdrImage.Pages.Length > 0)
                {
                    var firstPage = (CdrImagePage)cdrImage.Pages[0];
                    rasterOptions.PageWidth = firstPage.Width;
                    rasterOptions.PageHeight = firstPage.Height;
                }

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}