using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.pdf";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX with CMX-specific load options (allows custom font handling if needed)
            var loadOptions = new Aspose.Imaging.ImageLoadOptions.CmxLoadOptions();

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Configure CMX rasterization options for vector fidelity
                var cmxRasterOptions = new CmxRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                pdfOptions.VectorRasterizationOptions = cmxRasterOptions;

                // Save as PDF preserving vector data and embedded fonts
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}