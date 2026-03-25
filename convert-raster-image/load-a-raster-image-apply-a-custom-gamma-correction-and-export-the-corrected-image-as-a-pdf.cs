using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample_gamma_corrected.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image, apply gamma correction, and save as PDF
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access AdjustGamma
            var rasterImage = (RasterImage)image;

            // Apply gamma correction (same coefficient for R, G, B)
            rasterImage.AdjustGamma(2.2f);

            // Save the corrected image as PDF
            rasterImage.Save(outputPath, new PdfOptions());
        }
    }
}