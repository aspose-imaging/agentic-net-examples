using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\Images\\input.psd";
        string outputPath = "C:\\Images\\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Apply per‑channel gamma values: Red=1.1, Green=1.0, Blue=0.9
            if (image is RasterImage rasterImage)
            {
                rasterImage.AdjustGamma(1.1f, 1.0f, 0.9f);
            }

            // Export the image to PDF
            PdfOptions pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}