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

        // Load the CDR image
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Retrieve and log the number of pages (layers)
            int pageCount = cdrImage.PageCount;
            Console.WriteLine($"Cdr file contains {pageCount} page(s).");

            // Iterate through each page and export to a separate PDF file
            for (int i = 0; i < pageCount; i++)
            {
                // Access the specific page
                CdrImagePage page = (CdrImagePage)cdrImage.Pages[i];

                // Prepare PDF output path
                string outputPath = Path.Combine(outputDirectory, $"page{i}.pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set up PDF options with rasterization settings matching the page size
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
                Console.WriteLine($"Exported page {i} to PDF: {outputPath}");
            }
        }
    }
}