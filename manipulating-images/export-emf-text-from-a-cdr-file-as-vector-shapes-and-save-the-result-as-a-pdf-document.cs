using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\sample.cdr";
        string outputPath = @"C:\Data\sample.cdr.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR file
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options with vector rasterization settings
            PdfOptions pdfOptions = new PdfOptions();
            CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
            {
                // Render text as vector shapes
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                Positioning = PositioningTypes.DefinedByDocument
            };
            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}