using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths (relative)
        string inputPath = Path.Combine("Input", "sample.otg");
        string outputPath = Path.Combine("Output", "sample.pdf");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Custom DPI and margins
        const int dpiX = 300;
        const int dpiY = 300;
        const int margin = 50; // margin in pixels

        // Load OTG image and convert to PDF with custom settings
        using (Image image = Image.Load(inputPath))
        {
            // Configure OTG rasterization options
            OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size,
                BorderX = margin,
                BorderY = margin,
                BackgroundColor = Color.White
            };

            // Configure PDF options with DPI and vector rasterization
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = otgOptions,
                ResolutionSettings = new ResolutionSetting(dpiX, dpiY)
            };

            // Save the PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}