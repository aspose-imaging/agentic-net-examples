using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

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
            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PNG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, apply dithering, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    TiffImage tiffImage = (TiffImage)image;

                    // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                    tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

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
 * 1. When a developer needs to convert a large collection of high‑resolution TIFF scans into web‑friendly PNG files with 1‑bit Floyd‑Steinberg dithering to reduce file size while preserving visual detail.
 * 2. When an archival system requires batch processing of scanned documents stored as TIFF, applying dithering to improve readability on low‑color displays before saving them as PNG for browser preview.
 * 3. When a printing workflow must automatically transform multi‑page TIFF images into single‑page PNG assets with a binary palette, using Aspose.Imaging in C# to ensure consistent output across a folder.
 * 4. When a medical imaging application has to generate thumbnail PNGs from a directory of TIFF radiology images, applying Floyd‑Steinberg dithering to maintain contrast in the reduced‑color thumbnails.
 * 5. When a GIS developer wants to preprocess satellite TIFF tiles by dithering them to 1‑bit and exporting them as PNG for faster loading in a web map, using a C# batch script with Aspose.Imaging.
 */