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

        // Load the CDR image
        using (CdrImage image = (CdrImage)Image.Load(inputPath))
        {
            // Rotate the image by 90 degrees (clockwise)
            image.Rotate(90f);

            // Configure PDF export options with vector rasterization settings
            PdfOptions pdfOptions = new PdfOptions();
            CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
            {
                // Preserve vector quality settings
                Positioning = PositioningTypes.DefinedByDocument,
                SmoothingMode = SmoothingMode.None,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel
            };

            // Optionally set page size to match the source image
            rasterOptions.PageWidth = image.Width;
            rasterOptions.PageHeight = image.Height;

            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save the rotated image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}