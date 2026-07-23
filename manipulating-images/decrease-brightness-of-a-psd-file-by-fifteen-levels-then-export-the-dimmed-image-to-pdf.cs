using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/output.pdf";

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
                // Cast to RasterImage to adjust brightness
                RasterImage raster = (RasterImage)image;
                // Decrease brightness by 15 levels
                raster.AdjustBrightness(-15);

                // Prepare PDF options
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    // Save the adjusted image as PDF
                    image.Save(outputPath, pdfOptions);
                }
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
 * 1. When a developer needs to dim a Photoshop PSD file by fifteen brightness levels before converting it to a PDF for consistent printing or archival.
 * 2. When an automated workflow must batch‑process PSD assets, reduce their brightness to meet brand guidelines, and generate PDF previews for client review.
 * 3. When a web application uploads user‑provided PSD designs, applies a subtle darkening effect to improve on‑screen readability, and then serves the result as a PDF document.
 * 4. When a digital publishing system has to adjust the exposure of layered PSD artwork to match a printed catalog’s visual style and export the final page as a PDF.
 * 5. When a C# utility needs to verify that a PSD image exists, safely adjust its brightness, and reliably save the modified image in PDF format using Aspose.Imaging for .NET.
 */