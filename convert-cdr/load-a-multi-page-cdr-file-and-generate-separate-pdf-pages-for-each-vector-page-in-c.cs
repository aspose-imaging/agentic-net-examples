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
            string inputPath = @"C:\temp\input.cdr";
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
                // Ensure all pages are cached (optional but improves performance)
                cdrImage.CacheData();

                // Iterate through each page
                for (int i = 0; i < cdrImage.PageCount; i++)
                {
                    // Retrieve the specific page
                    CdrImagePage page = (CdrImagePage)cdrImage.Pages[i];
                    page.CacheData();

                    // Prepare PDF save options
                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        PageWidth = page.Width,
                        PageHeight = page.Height
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Build output file path for this page
                    string outputPath = Path.Combine(outputDirectory, $"page_{i}.pdf");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as a separate PDF
                    page.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}