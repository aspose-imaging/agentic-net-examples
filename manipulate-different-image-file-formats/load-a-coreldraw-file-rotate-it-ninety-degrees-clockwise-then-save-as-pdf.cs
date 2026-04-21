using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.cdr";
        string outputPath = @"C:\Temp\sample_rotated.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CorelDRAW file
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise
            cdrImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Prepare PDF save options with rasterization settings
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                }
            };

            // Save the rotated image as PDF
            cdrImage.Save(outputPath, pdfOptions);
        }
    }
}