using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\sample.pdf";

        try
        {
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
                // Configure PDF export options
                var pdfOptions = new PdfOptions();

                // Set vector rasterization options specific to CMX
                var rasterOptions = new CmxRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as PDF with vector fidelity
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}