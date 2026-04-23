using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.cmx";
        string outputPath = "Output/sample.pdf";

        // Validate input file existence
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
            // Configure PDF options with A4 page size
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // A4 size in points (1 point = 1/72 inch)
                pdfOptions.PageSize = new SizeF(595f, 842f);

                // Set vector rasterization options for CMX
                pdfOptions.VectorRasterizationOptions = new CmxRasterizationOptions
                {
                    PageSize = new SizeF(595f, 842f),
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}