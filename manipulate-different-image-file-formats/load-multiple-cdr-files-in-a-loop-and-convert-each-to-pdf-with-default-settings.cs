using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded list of input CDR files
        string[] inputFiles = new string[]
        {
            @"C:\Input\sample1.cdr",
            @"C:\Input\sample2.cdr"
        };

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine base output directory and file name
            string outputDirectory = Path.GetDirectoryName(inputPath);
            string baseFileName = Path.GetFileNameWithoutExtension(inputPath);

            // Ensure output directory exists (unconditional)
            Directory.CreateDirectory(outputDirectory);

            // Load the CDR image
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Iterate through all pages in the CDR document
                for (int pageIndex = 0; pageIndex < image.Pages.Length; pageIndex++)
                {
                    var page = (CdrImagePage)image.Pages[pageIndex];

                    // Prepare PDF options with rasterization settings matching the page size
                    var pdfOptions = new PdfOptions();
                    var rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        PageWidth = page.Width,
                        PageHeight = page.Height
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Build output PDF file name for the current page
                    string outputPdfPath = Path.Combine(outputDirectory, $"{baseFileName}_page{pageIndex}.pdf");

                    // Ensure the directory for the output file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

                    // Save the page as PDF
                    page.Save(outputPdfPath, pdfOptions);
                }
            }
        }
    }
}