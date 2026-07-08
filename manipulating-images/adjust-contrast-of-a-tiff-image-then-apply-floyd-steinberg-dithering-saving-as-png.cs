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
        string inputPath = @"c:\temp\input.tif";
        string outputPath = @"c:\temp\output.png";

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
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access TIFF‑specific methods
                TiffImage tiffImage = (TiffImage)image;

                // Adjust contrast (example value: 50)
                tiffImage.AdjustContrast(50f);

                // Apply Floyd‑Steinberg dithering with 1‑bit palette
                tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Save the processed image as PNG
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to improve the visual quality of a scanned document by increasing contrast before converting a multi‑page TIFF to a web‑friendly PNG.
 * 2. When an application must reduce the file size of a high‑resolution TIFF by applying Floyd‑Steinberg dithering to a 1‑bit palette and saving the result as PNG for faster download.
 * 3. When a batch‑processing tool has to prepare archival TIFF images for printing on monochrome printers, adjusting contrast and dithering to ensure crisp black‑and‑white output.
 * 4. When a medical imaging system requires conversion of diagnostic TIFF scans to PNG while enhancing contrast and applying error‑diffusion dithering to preserve detail in low‑bit displays.
 * 5. When a GIS workflow needs to transform satellite TIFF layers into PNG tiles with adjusted contrast and Floyd‑Steinberg dithering for consistent map rendering.
 */