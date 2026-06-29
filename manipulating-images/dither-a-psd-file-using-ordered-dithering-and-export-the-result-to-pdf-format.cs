using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input.psd";
            string outputPath = "output.pdf";

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
                // Cast to RasterImage to access Dither method
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("The loaded image is not a raster image and cannot be dithered.");
                    return;
                }

                // Perform ordered‑like dithering (using ThresholdDithering as the closest available method)
                raster.Dither(DitheringMethod.ThresholdDithering, 8);

                // Save the dithered image as PDF
                PdfOptions pdfOptions = new PdfOptions();
                raster.Save(outputPath, pdfOptions);
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
 * 1. When a graphic designer needs to convert a high‑resolution Photoshop PSD file into a lightweight PDF for client review while preserving visual fidelity through ordered dithering.
 * 2. When a publishing workflow requires batch processing of PSD assets to PDF with dithering to ensure consistent grayscale output on low‑color‑depth printers.
 * 3. When a web application must generate PDF previews of PSD files on the fly, applying threshold dithering to reduce file size without losing essential detail.
 * 4. When an archival system stores design files as PDFs and uses ordered‑like dithering to maintain the appearance of complex PSD layers in a single rasterized document.
 * 5. When a C#‑based document conversion service needs to transform PSD images into PDF format with dithering to meet compliance standards for monochrome printing.
 */