using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    // Asynchronous conversion of a CDR file to PDF
    static async Task Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.cdr";
        string outputPath = @"C:\output\sample.pdf";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            await ConvertCdrToPdfAsync(inputPath, outputPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Performs the conversion on a background thread
    private static Task ConvertCdrToPdfAsync(string inputPath, string outputPath)
    {
        return Task.Run(() =>
        {
            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Use the first page (index 0) for conversion
                var page = (CdrImagePage)cdrImage.Pages[0];

                // Set up PDF options with rasterization settings
                var pdfOptions = new PdfOptions();
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = page.Width,
                    PageHeight = page.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the page as PDF
                page.Save(outputPath, pdfOptions);
            }
        });
    }
}