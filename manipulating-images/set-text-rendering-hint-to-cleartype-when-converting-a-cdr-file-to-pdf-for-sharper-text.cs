using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Input\sample.cdr";
        string outputPath = @"C:\Output\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options with ClearType text rendering
            var pdfOptions = new PdfOptions();
            var rasterOptions = new CdrRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            };
            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}