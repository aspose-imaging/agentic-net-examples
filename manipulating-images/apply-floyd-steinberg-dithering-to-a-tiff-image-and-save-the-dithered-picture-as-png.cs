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
            string inputPath = @"c:\temp\sample.tif";
            string outputPath = @"c:\temp\sample.FloydSteinbergDithering1.png";

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
                // Cast to TiffImage to access Dither method
                TiffImage tiffImage = (TiffImage)image;

                // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Save the dithered image as PNG
                tiffImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert high‑resolution 1‑bit TIFF scans of engineering drawings into smaller PNG files while preserving visual detail using Floyd‑Steinberg dithering.
 * 2. When an application must generate web‑friendly PNG thumbnails from legacy TIFF photographs and wants to reduce banding artifacts by applying dithering in C#.
 * 3. When a document‑management system imports multi‑page TIFF archives and requires each page to be saved as a dithered PNG for faster preview rendering.
 * 4. When a game‑asset pipeline processes TIFF textures and needs to create low‑color PNG sprites with Floyd‑Steinberg dithering to maintain contrast on limited palettes.
 * 5. When a medical‑imaging tool exports TIFF X‑ray images to PNG format for patient portals and uses dithering to improve readability on standard monitors.
 */