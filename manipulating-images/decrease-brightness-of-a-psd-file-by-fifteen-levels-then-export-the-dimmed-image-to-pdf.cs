using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input PSD file (relative path)
            string inputPath = "Input/sample.psd";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output PDF file (relative path)
            string outputPath = "Output/dimmed.pdf";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel manipulation
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                // Decrease brightness by 15 levels
                raster.AdjustBrightness(-15);

                // Save the adjusted image as PDF
                using (PdfOptions pdfOptions = new PdfOptions())
                {
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
 * 1. When a graphic designer needs to automatically dim a Photoshop PSD mockup by fifteen brightness levels before generating a client‑ready PDF portfolio.
 * 2. When a web service processes uploaded PSD files, reduces their brightness to meet brand guidelines, and returns the result as a PDF document.
 * 3. When an automated build pipeline converts dark‑theme PSD assets into printable PDF handouts with consistent reduced brightness.
 * 4. When a digital archiving tool batch‑processes legacy PSD scans, lowers their brightness to improve readability, and stores them in PDF format for long‑term preservation.
 * 5. When a Windows desktop application lets users adjust the brightness of a PSD image programmatically and export the edited version directly to PDF for sharing.
 */