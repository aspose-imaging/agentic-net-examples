// HOW-TO: Apply Per‑Channel Gamma to PSD and Save as PDF in C# (Aspose.Imaging for .NET)
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
                if (image is RasterImage rasterImage)
                {
                    rasterImage.AdjustGamma(1.1f, 1.0f, 0.9f);
                }

                // Export the image to PDF
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
 * 1. When you need to adjust the brightness of individual color channels in a Photoshop PSD before generating a printable PDF report.
 * 2. When a web service must convert uploaded PSD files to PDF while applying custom gamma values to match brand color standards.
 * 3. When automating a batch workflow that prepares design assets by correcting channel gamma and exporting them as PDF for client review.
 * 4. When integrating Aspose.Imaging into a C# application to ensure accurate color reproduction of PSD layers in the final PDF document.
 * 5. When creating a desktop utility that validates PSD files, applies per‑channel gamma correction, and saves the result as a PDF for archival purposes.
 */
