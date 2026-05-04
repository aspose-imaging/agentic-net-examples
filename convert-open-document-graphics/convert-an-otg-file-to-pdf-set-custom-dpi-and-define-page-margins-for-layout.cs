using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths (relative)
        string inputPath = Path.Combine("Input", "sample.otg");
        string outputPath = Path.Combine("Output", "sample.pdf");

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

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure OTG rasterization options (margins, background, page size)
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size,
                    BorderX = 50, // horizontal margin
                    BorderY = 50, // vertical margin
                    BackgroundColor = Color.White
                };

                // Configure PDF options with custom DPI
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = otgOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300) // DPI X, DPI Y
                };

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