using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.webp";
        string outputPath = "Output\\result.pdf";
        string tempPath = "Output\\temp_quality.webp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

        // Load the original WebP image and re‑save it with the desired quality
        using (Image image = Image.Load(inputPath))
        {
            var webpOptions = new WebPOptions
            {
                Lossless = false,   // Use lossy compression
                Quality = 80        // Adjust quality (0‑100)
            };
            image.Save(tempPath, webpOptions);
        }

        // Load the quality‑adjusted WebP and convert it to PDF
        using (Image adjusted = Image.Load(tempPath))
        {
            var pdfOptions = new PdfOptions();
            adjusted.Save(outputPath, pdfOptions);
        }
    }
}