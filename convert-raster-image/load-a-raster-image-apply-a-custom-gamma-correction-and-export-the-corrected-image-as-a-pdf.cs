using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample_gamma.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Apply gamma correction (same value for all channels)
                if (image is RasterImage rasterImage)
                {
                    rasterImage.AdjustGamma(2.2f);
                }
                else if (image is RasterCachedImage cachedImage)
                {
                    cachedImage.AdjustGamma(2.2f);
                }

                // Save the corrected image as PDF
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a PNG screenshot to a PDF while applying gamma correction to improve print brightness and contrast.
 * 2. When an application must batch‑process raster images, adjust their gamma uniformly, and save the results as PDF files for archival.
 * 3. When a reporting tool has to embed a raster chart into a PDF report and ensure consistent visual appearance across devices by correcting gamma.
 * 4. When a web service receives a JPEG image, applies gamma correction for accurate color rendering, and returns the image as a PDF for downstream consumption.
 * 5. When a desktop utility must verify the input image, create the output directory if missing, apply gamma adjustment, and export the corrected image as a PDF for compliance documentation.
 */