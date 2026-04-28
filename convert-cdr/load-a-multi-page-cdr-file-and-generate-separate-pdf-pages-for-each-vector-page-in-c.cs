using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cdr";
            string outputDirectory = "Output";

            // Validate input file existence
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
                // Cache the whole document
                cdrImage.CacheData();

                // Iterate through each page
                foreach (Image img in cdrImage.Pages)
                {
                    // Cast to CdrImagePage and ensure disposal
                    using (CdrImagePage page = (CdrImagePage)img)
                    {
                        page.CacheData();

                        // Prepare output file path for this page
                        string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.pdf");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Configure PDF and rasterization options
                        PdfOptions pdfOptions = new PdfOptions();
                        CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                        {
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None,
                            Positioning = PositioningTypes.DefinedByDocument,
                            PageWidth = page.Width,
                            PageHeight = page.Height
                        };
                        pdfOptions.VectorRasterizationOptions = rasterOptions;

                        // Save the current page as a separate PDF
                        page.Save(outputPath, pdfOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}