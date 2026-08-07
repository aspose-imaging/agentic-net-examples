using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/blurred.pdf";

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
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 3.0
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 3.0));

                // Save the blurred image as PDF
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    raster.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to automatically soften the details of a Photoshop PSD design before sending it to a client as a non‑editable PDF report.
 * 2. When an e‑learning platform wants to generate preview PDFs of high‑resolution PSD assets with a Gaussian blur (sigma 3) to protect copyrighted content.
 * 3. When a marketing automation script must batch‑process PSD files, apply a consistent blur effect, and archive the results in PDF format for compliance review.
 * 4. When a document management system requires converting layered PSD artwork into searchable PDF files while reducing visual noise using a Gaussian blur filter in C#.
 * 5. When a print‑preflight tool needs to quickly render a blurred version of a PSD mockup as a PDF to verify layout spacing without exposing the original layers.
 */