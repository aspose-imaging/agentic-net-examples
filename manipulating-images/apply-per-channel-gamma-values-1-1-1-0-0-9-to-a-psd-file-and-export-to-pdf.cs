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
            string inputPath = "C:\\temp\\input.psd";
            string outputPath = "C:\\temp\\output.pdf";

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
                // Apply per‑channel gamma correction (R=1.1, G=1.0, B=0.9)
                if (image is RasterImage raster)
                {
                    raster.AdjustGamma(1.1f, 1.0f, 0.9f);
                }

                // Export to PDF
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
 * 1. When a developer needs to correct color balance of a Photoshop PSD by applying different gamma values to the red, green, and blue channels before generating a printable PDF document.
 * 2. When an automated image‑processing pipeline must batch‑process PSD files, adjust per‑channel gamma to match brand color guidelines, and export the results as PDF reports.
 * 3. When a web service receives user‑uploaded PSD artwork, applies subtle gamma tweaks to enhance contrast per channel, and returns a PDF preview for client review.
 * 4. When a desktop application converts layered PSD designs into PDF portfolios while ensuring that each color channel is calibrated with specific gamma settings for accurate on‑screen rendering.
 * 5. When a quality‑control script validates that a PSD file exists, performs per‑channel gamma correction, and saves the final output as a PDF for archival or compliance purposes.
 */