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
            string inputPath = @"C:\Images\sample.psd";
            string outputPath = @"C:\Images\output.pdf";

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
                // Cast to RasterImage to access AdjustGamma
                if (image is RasterImage rasterImage)
                {
                    // Apply per‑channel gamma values: Red=1.1, Green=1.0, Blue=0.9
                    rasterImage.AdjustGamma(1.1f, 1.0f, 0.9f);
                }

                // Save as PDF using default PDF options
                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When a developer needs to correct color balance of a Photoshop PSD by applying different gamma values to red, green, and blue channels before sharing it as a PDF document.
 * 2. When an automated image‑processing pipeline must convert layered PSD files to PDF while adjusting per‑channel gamma to match print‑ready color profiles.
 * 3. When a web service generates PDF previews of user‑uploaded PSD artwork and wants to enhance contrast by increasing red gamma, keeping green unchanged, and decreasing blue gamma.
 * 4. When a desktop application prepares marketing assets by loading a PSD, applying custom gamma correction per channel, and exporting the result as a PDF for client review.
 * 5. When a batch job processes a folder of PSD files, applies specific per‑channel gamma adjustments to improve visual consistency, and saves each file as a PDF for archival purposes.
 */