using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.pdf";

            // Verify input file exists
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
                // Configure OTG rasterization options
                var otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size,
                    BorderX = 50, // horizontal margin
                    BorderY = 50, // vertical margin
                    BackgroundColor = Color.White
                };

                // Configure PDF save options with custom DPI
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = otgOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300) // DPI X=300, Y=300
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