using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.psd";
        string outputPath = @"C:\Images\output.pdf";

        // Verify that the input PSD file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Dither method
            if (image is RasterImage rasterImage)
            {
                // Apply ordered dithering approximation using ThresholdDithering
                // with an 8‑bit palette (256 colors). Adjust bitsCount as needed.
                rasterImage.Dither(DitheringMethod.ThresholdDithering, 8);
            }

            // Prepare PDF save options (default settings)
            var pdfOptions = new PdfOptions();

            // Save the dithered image as a PDF file
            image.Save(outputPath, pdfOptions);
        }
    }
}