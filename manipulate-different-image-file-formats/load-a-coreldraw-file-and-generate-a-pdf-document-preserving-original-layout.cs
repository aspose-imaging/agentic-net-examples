using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
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
            // Prepare PDF export options
            var pdfOptions = new PdfOptions();

            // Configure rasterization options specific to CDR
            var rasterizationOptions = new CdrRasterizationOptions
            {
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                Positioning = Aspose.Imaging.ImageOptions.PositioningTypes.DefinedByDocument
            };

            pdfOptions.VectorRasterizationOptions = rasterizationOptions;

            // Save the image as PDF preserving original layout
            image.Save(outputPath, pdfOptions);
        }
    }
}