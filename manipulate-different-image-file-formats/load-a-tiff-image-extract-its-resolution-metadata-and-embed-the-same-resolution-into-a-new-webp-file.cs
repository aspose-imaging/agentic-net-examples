using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Images\output.webp";

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

            // Load the TIFF image
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Cast to TiffImage to access resolution properties
                TiffImage tiff = (TiffImage)tiffImage;

                // Retrieve horizontal and vertical DPI
                double dpiX = tiff.HorizontalResolution;
                double dpiY = tiff.VerticalResolution;

                // Apply the same resolution (explicitly) before saving
                tiff.SetResolution(dpiX, dpiY);

                // Prepare WebP save options
                WebPOptions webpOptions = new WebPOptions
                {
                    // Example: keep lossless; adjust as needed
                    Lossless = true
                };

                // Save as WebP with the same resolution metadata
                tiff.Save(outputPath, webpOptions);
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
 * 1. When a web application must convert high‑resolution TIFF scans to WebP for faster page loads while preserving the original DPI metadata for accurate print scaling.
 * 2. When a digital asset management system needs to ingest TIFF photographs, extract their horizontal and vertical resolution, and store them as lossless WebP files with the same resolution for consistent downstream processing.
 * 3. When an e‑commerce platform automates the generation of product thumbnails by converting supplier‑provided TIFF images to WebP while keeping the original DPI to ensure size‑aware display on high‑density screens.
 * 4. When a medical imaging workflow requires converting diagnostic TIFF slides to WebP for secure web viewing, retaining the exact resolution metadata to maintain measurement fidelity.
 * 5. When a GIS (Geographic Information System) tool batch‑processes georeferenced TIFF maps into WebP format, embedding the original DPI so that map scales remain correct in web‑based viewers.
 */