using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CDR with default load options (fonts embedded automatically)
            var loadOptions = new Aspose.Imaging.ImageLoadOptions.CdrLoadOptions();

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Prepare PDF save options
                var pdfOptions = new PdfOptions();

                // Configure rasterization to preserve embedded fonts
                var rasterizationOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument,
                    BackgroundColor = Color.White
                };

                pdfOptions.VectorRasterizationOptions = rasterizationOptions;

                // Save as PDF with embedded fonts
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}