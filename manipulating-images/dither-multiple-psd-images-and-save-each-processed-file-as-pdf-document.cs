// HOW-TO: Batch Dither PSD Files and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PSD files
            string[] inputPaths = new string[]
            {
                @"C:\Images\image1.psd",
                @"C:\Images\image2.psd"
            };

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path (same folder, same name with .pdf extension)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PSD image
                using (Image image = Image.Load(inputPath))
                {
                    // Apply dithering if the image is raster based
                    if (image is RasterImage rasterImage)
                    {
                        // Floyd‑Steinberg dithering with 1‑bit palette (black & white)
                        rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 1);
                    }

                    // Prepare PDF save options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the processed image as PDF
                    image.Save(outputPath, pdfOptions);
                }

                Console.WriteLine($"Processed and saved: {outputPath}");
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
 * 1. When you need to prepare high‑contrast black‑and‑white PDFs from a series of Photoshop PSD designs for fast printing or archival.
 * 2. When an application must automatically convert multiple layered PSD assets into PDF documents while applying Floyd‑Steinberg dithering to reduce file size.
 * 3. When a workflow requires batch processing of PSD artwork to generate PDF proofs with a 1‑bit palette for e‑book publishing.
 * 4. When you want to integrate image preprocessing in a C# service that transforms PSD files into PDF format for downstream OCR or document management systems.
 * 5. When a developer needs to ensure each PSD is saved as a PDF in the same folder, handling missing files and creating output directories on the fly.
 */
