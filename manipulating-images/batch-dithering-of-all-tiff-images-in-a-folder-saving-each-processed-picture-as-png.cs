using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Get all TIFF files in the input folder
            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in tiffFiles)
            {
                // Process only .tif and .tiff extensions
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".tif" && extension != ".tiff")
                    continue;

                // Verify input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Load the TIFF image
                using (Image image = Image.Load(filePath))
                {
                    // Cast to TiffImage to access Dither method
                    TiffImage tiffImage = (TiffImage)image;

                    // Apply Floyd‑Steinberg dithering with 1‑bit palette
                    tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                    // Build output PNG path
                    string outputPath = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(filePath) + ".png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image as PNG
                    tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert a collection of high‑resolution scanned TIFF documents into web‑friendly PNG files with 1‑bit Floyd‑Steinberg dithering to reduce file size while preserving visual detail.
 * 2. When an archival system requires automated processing of incoming TIFF images to generate monochrome PNG previews for quick browsing in a .NET application.
 * 3. When a printing workflow must batch‑process TIFF artwork by applying dithering and saving as PNG to ensure consistent rendering on low‑color‑depth printers.
 * 4. When a digital asset management tool needs to ingest a folder of TIFF photographs and create optimized PNG thumbnails using Aspose.Imaging’s Dither method in C#.
 * 5. When a GIS application must transform a set of geospatial TIFF layers into PNG overlays with 1‑bit dithering for faster map rendering on the client side.
 */