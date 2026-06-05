using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "sample.cmx");
            string outputPath = Path.Combine("Output", "sample.pdf");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                // Configure PDF options with A4 page size
                var pdfOptions = new PdfOptions
                {
                    PageSize = new SizeF(8.27f, 11.69f) // A4 size in inches
                };

                // Set vector rasterization options for proper rendering
                var rasterOptions = new CmxRasterizationOptions
                {
                    PageSize = new SizeF(8.27f, 11.69f),
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}