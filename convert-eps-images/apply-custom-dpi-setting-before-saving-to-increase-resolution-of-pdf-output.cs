using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Images\output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF save options with a higher DPI (e.g., 300 dpi)
            PdfOptions pdfOptions = new PdfOptions
            {
                // Do not rely on the original image DPI; use the specified resolution instead
                UseOriginalImageResolution = false,
                // Set the desired resolution for the PDF output
                ResolutionSettings = new ResolutionSetting(300.0, 300.0)
            };

            // Save the image as PDF with the custom DPI settings
            image.Save(outputPath, pdfOptions);
        }
    }
}