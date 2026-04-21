using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.odg";
        string outputPath = "Output/sample.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options (margins, background, page size)
            var rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                BorderX = 20, // left/right margin
                BorderY = 20, // top/bottom margin
                PageSize = image.Size
            };

            // Configure PDF save options with custom DPI
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions,
                ResolutionSettings = new ResolutionSetting(300, 300) // 300 DPI X and Y
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}