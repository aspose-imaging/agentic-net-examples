using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\source.bmp";
            string outputPath = @"C:\temp\output.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image bmpImage = Image.Load(inputPath))
            {
                // Cast to RasterImage for conversion
                RasterImage raster = bmpImage as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load raster image.");
                    return;
                }

                // Create a JPEG2000 image with custom bits per sample (e.g., 12 bits)
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(raster, 12))
                {
                    // Save the JPEG2000 image using default options
                    jpeg2000Image.Save(outputPath, new Jpeg2000Options());

                    // Verify and display output file size
                    long fileSize = new FileInfo(outputPath).Length;
                    Console.WriteLine($"Output file size: {fileSize} bytes");
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
 * 1. When a developer needs to convert legacy BMP assets to high‑quality JPEG2000 files with a custom 12‑bit depth for archival storage while ensuring the output size is within limits.
 * 2. When an imaging application must programmatically generate JPEG2000 images from user‑uploaded BMP pictures and verify the resulting file size before sending it to a web service.
 * 3. When a medical imaging system requires converting 12‑bit grayscale BMP scans to JPEG2000 format to preserve diagnostic detail and then log the file size for compliance reporting.
 * 4. When a GIS tool needs to batch‑process BMP elevation maps into JPEG2000 tiles with a specific bits‑per‑sample setting and confirm each tile’s size for efficient tiling.
 * 5. When a digital publishing workflow automates the transformation of BMP source graphics into JPEG2000 for print‑ready PDFs and checks the file size to stay under publishing constraints.
 */