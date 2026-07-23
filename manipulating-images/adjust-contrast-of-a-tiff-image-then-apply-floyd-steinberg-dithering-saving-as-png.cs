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
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.tif";
            string outputPath = @"c:\temp\output.png";

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

                // Apply Floyd‑Steinberg dithering with a 1‑bit palette
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
 * 2. When an application must reduce a high‑resolution TIFF to a 1‑bit black‑and‑white PNG using Floyd‑Steinberg dithering for printing on monochrome printers.
 * 3. When a batch‑processing tool has to prepare archival TIFF images for mobile devices by adjusting contrast and applying dithering to keep file size low.
 * 4. When a GIS system requires converting satellite TIFF imagery to PNG while enhancing contrast and preserving edge detail through dithering.
 * 5. When a digital archiving workflow needs to standardize incoming TIFF files by normalizing contrast and generating a PNG preview with Floyd‑Steinberg dithering.
 */