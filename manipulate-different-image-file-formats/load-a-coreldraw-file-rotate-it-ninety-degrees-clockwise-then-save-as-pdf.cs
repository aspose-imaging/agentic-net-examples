using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_rotated.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CorelDRAW file
        using (CdrImage image = (CdrImage)Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Prepare PDF save options with rasterization settings
            var pdfOptions = new PdfOptions();
            var rasterOptions = new CdrRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                Positioning = PositioningTypes.DefinedByDocument
            };
            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save the rotated image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}