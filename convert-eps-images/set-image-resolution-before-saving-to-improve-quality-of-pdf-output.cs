using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Output\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options with higher resolution
            PdfOptions pdfOptions = new PdfOptions
            {
                ResolutionSettings = new ResolutionSetting(300.0, 300.0) // 300 DPI for better quality
            };

            // Save the image as PDF using the configured options
            image.Save(outputPath, pdfOptions);
        }
    }
}