using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputImages";
            string outputDir = @"C:\OutputPdfs";

            // List of PSD files to process
            string[] psdFiles = new[]
            {
                "sample1.psd",
                "sample2.psd",
                "sample3.psd"
            };

            foreach (string fileName in psdFiles)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputDir, fileName);
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".pdf");

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
                    // Cast to RasterImage to apply dithering
                    RasterImage rasterImage = image as RasterImage;
                    if (rasterImage != null)
                    {
                        // Apply Floyd‑Steinberg dithering with a 1‑bit palette (black & white)
                        rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 1);
                    }

                    // Prepare PDF save options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the processed image as PDF
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
 * 1. When a developer needs to generate printable black‑and‑white PDFs from a set of Photoshop PSD files for a fast‑preview workflow, they can use this code to dither each image and save it as a PDF.
 * 2. When an e‑commerce platform must automatically create low‑size PDF catalog pages from high‑resolution PSD product images while preserving visual contrast, this code provides batch dithering and conversion.
 * 3. When a document management system requires archival of design assets as PDFs with 1‑bit dithering to reduce storage costs, the code can process multiple PSD files in one run.
 * 4. When a web service offers on‑the‑fly conversion of uploaded PSD files to PDF for mobile devices, applying Floyd‑Steinberg dithering ensures the output is clear on monochrome screens.
 * 5. When a QA automation script needs to validate that PSD files render correctly after dithering by comparing the resulting PDFs, this snippet automates loading, dithering, and saving.
 */