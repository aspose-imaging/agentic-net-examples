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
        string inputPath = @"C:\temp\sample.cdr";
        string outputDirectory = @"C:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (will also work if outputDirectory is null)
        Directory.CreateDirectory(outputDirectory);

        // Load the CDR image
        using (CdrImage image = (CdrImage)Image.Load(inputPath))
        {
            // Log the number of pages (layers) in the document
            Console.WriteLine($"Page count: {image.PageCount}");

            // Export each page to a separate PDF file
            for (int i = 0; i < image.PageCount; i++)
            {
                // Prepare output file path for the current page
                string outputPath = Path.Combine(outputDirectory, $"page{i}.pdf");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Get the specific page
                CdrImagePage page = (CdrImagePage)image.Pages[i];

                // Set up PDF export options with rasterization settings
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = page.Width,
                    PageHeight = page.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the page as PDF
                page.Save(outputPath, pdfOptions);
                Console.WriteLine($"Exported page {i} to {outputPath}");
            }
        }
    }
}