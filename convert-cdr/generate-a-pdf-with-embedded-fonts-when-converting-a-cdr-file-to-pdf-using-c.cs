using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded relative input and output paths
        string inputPath = Path.Combine("Input", "sample.cdr");
        string outputPath = Path.Combine("Output", "sample.pdf");

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
            // Configure PDF save options with CDR rasterization settings
            var pdfOptions = new PdfOptions();
            var rasterOptions = new CdrRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                Positioning = PositioningTypes.DefinedByDocument
            };
            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save as PDF; fonts used in the CDR are embedded automatically
            image.Save(outputPath, pdfOptions);
        }
    }
}