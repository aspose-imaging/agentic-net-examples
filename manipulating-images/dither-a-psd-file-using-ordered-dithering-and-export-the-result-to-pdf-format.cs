using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.psd";
        string outputPath = @"C:\Images\sample_dithered.pdf";

        try
        {
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
                RasterImage rasterImage = (RasterImage)image;

                // Perform ordered (threshold) dithering with a 4‑bit palette
                rasterImage.Dither(DitheringMethod.ThresholdDithering, 4);

                // Prepare PDF export options (default settings)
                PdfOptions pdfOptions = new PdfOptions();

                // Save the dithered image as PDF
                rasterImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert a Photoshop PSD file into a PDF for web preview and wants to reduce the color depth using ordered (threshold) dithering with a 4‑bit palette.
 * 2. When an image‑processing service must generate printable PDFs from PSD artwork while preserving visual fidelity by applying raster‑level dithering before export.
 * 3. When a C# application automates batch conversion of PSD designs to PDF documents and requires a simple way to lower file size through threshold dithering.
 * 4. When a developer integrates Aspose.Imaging into a workflow that extracts raster data from layered PSD files, applies ordered dithering, and saves the result as a PDF for archival purposes.
 * 5. When a desktop tool needs to load a PSD, perform 4‑bit ordered dithering to simulate limited‑color output, and then export the processed image directly to PDF format.
 */