using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\input.wmf";
        string outputPath = @"C:\Temp\output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options to preserve original line thickness and colors
            var rasterOptions = new WmfRasterizationOptions
            {
                PageSize = image.Size,                         // Use original image size
                SmoothingMode = Aspose.Imaging.SmoothingMode.None, // Disable smoothing to keep line thickness
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel // Preserve text rendering
            };

            // Set up PDF export options with the vector rasterization options
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}