using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Entry point
    static async Task Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputDirectory = @"C:\Images\PdfOutput";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the CDR image with default load options
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath, new CdrLoadOptions()))
        {
            // Iterate through each page in the CDR document
            for (int i = 0; i < cdrImage.Pages.Length; i++)
            {
                // Prepare output PDF file path for the current page
                string outputPath = Path.Combine(outputDirectory, $"page_{i}.pdf");

                // Ensure the directory for the output file exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Retrieve the specific page
                var page = (CdrImagePage)cdrImage.Pages[i];

                // Configure PDF options with rasterization settings matching the page size
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = page.Width,
                        PageHeight = page.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                // Save the page to PDF asynchronously to keep UI responsive
                await Task.Run(() => page.Save(outputPath, pdfOptions));
            }
        }
    }
}