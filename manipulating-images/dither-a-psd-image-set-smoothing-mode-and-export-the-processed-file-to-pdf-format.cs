using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/processed.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image psdImage = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)psdImage;

                // Apply dithering
                raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                // Set smoothing mode
                Graphics graphics = new Graphics(raster);
                graphics.SmoothingMode = SmoothingMode.None;

                // Export to PDF
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
 * 1. When a developer needs to convert a high‑resolution Photoshop PSD file into a lightweight PDF for web preview while preserving visual fidelity by applying Floyd‑Steinberg dithering and disabling smoothing.
 * 2. When an e‑learning platform must generate printable PDF handouts from layered PSD assets and wants to reduce banding artifacts by dithering the raster image before saving.
 * 3. When a digital asset management system automates batch processing of PSD designs into PDF catalogs and requires consistent rendering by setting the graphics smoothing mode to None.
 * 4. When a mobile app backend prepares PDF reports from user‑uploaded PSD logos, using dithering to limit color depth and ensuring sharp edges by turning off smoothing.
 * 5. When a print‑on‑demand service needs to transform PSD artwork into PDF proofs quickly, applying 8‑bit dithering and explicit smoothing settings to match the printer’s color handling expectations.
 */