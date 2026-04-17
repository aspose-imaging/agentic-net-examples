using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.cdr";
        string outputDirectory = "Output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the multi‑page CDR image
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Cache the whole document to avoid repeated loading
            cdrImage.CacheData();

            // Iterate through each page
            for (int i = 0; i < cdrImage.PageCount; i++)
            {
                // Get the specific page and cache its data
                CdrImagePage page = (CdrImagePage)cdrImage.Pages[i];
                page.CacheData();

                // Prepare PDF options with rasterization settings
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
                string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.pdf");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as a separate PDF file
                page.Save(outputPath, pdfOptions);
            }
        }
    }
}