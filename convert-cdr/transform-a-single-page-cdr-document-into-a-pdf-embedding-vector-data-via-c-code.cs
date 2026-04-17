using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR document
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to CdrImage to access pages
            var cdrImage = (CdrImage)image;
            // Assume single page; get the first page
            var page = (CdrImagePage)cdrImage.Pages[0];

            // Prepare PDF options with vector rasterization settings
            var pdfOptions = new PdfOptions();
            var rasterOptions = new CdrRasterizationOptions
            {
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = Aspose.Imaging.SmoothingMode.None
            };
            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Set page dimensions to match the CDR page
            pdfOptions.VectorRasterizationOptions.PageWidth = page.Width;
            pdfOptions.VectorRasterizationOptions.PageHeight = page.Height;

            // Save the single page as PDF
            page.Save(outputPath, pdfOptions);
        }
    }
}