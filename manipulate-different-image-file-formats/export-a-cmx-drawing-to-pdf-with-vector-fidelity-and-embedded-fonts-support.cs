using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\output\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options with vector rasterization for CMX
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = new CmxRasterizationOptions
                {
                    // Preserve vector fidelity and embed fonts
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    Positioning = PositioningTypes.DefinedByDocument
                }
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}