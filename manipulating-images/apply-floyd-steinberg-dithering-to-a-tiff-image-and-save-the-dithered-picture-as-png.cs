using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.tif";
        string outputPath = @"C:\temp\sample.FloydSteinbergDithering1.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Dither method
                TiffImage tiffImage = (TiffImage)image;

                // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the dithered image as PNG
                tiffImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert high‑resolution scanned TIFF documents into compact black‑and‑white PNG files for web preview, applying Floyd‑Steinberg dithering to preserve visual detail.
 * 2. When an application must generate printable line‑art thumbnails from multi‑page TIFF archives by reducing them to a 1‑bit palette and saving as PNG for cross‑platform compatibility.
 * 3. When a legacy system stores medical imaging data as TIFF and a new portal requires PNG images with dithering to maintain contrast while minimizing file size.
 * 4. When a batch‑processing tool needs to automate the conversion of TIFF graphics to PNG with Floyd‑Steinberg error diffusion to meet accessibility guidelines for high‑contrast displays.
 * 5. When a developer is building a C# utility that validates the existence of source TIFF files, applies Floyd‑Steinberg dithering, and outputs PNG files to a specified folder for downstream image analysis.
 */