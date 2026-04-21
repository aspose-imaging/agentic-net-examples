using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\sample.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF save options with higher resolution for better quality
            PdfOptions pdfOptions = new PdfOptions
            {
                // Set desired DPI (e.g., 300x300)
                ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                // Do not inherit the original image DPI
                UseOriginalImageResolution = false
            };

            // Save the image as PDF using the configured options
            image.Save(outputPath, pdfOptions);
        }
    }
}