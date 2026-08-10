// HOW-TO: Apply Floyd Steinberg Dithering to CDR and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cdr";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Attempt to cast to a raster image to apply dithering
                if (image is RasterImage rasterImage)
                {
                    // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                    rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 1);
                }
                else if (image is TiffImage tiffImage)
                {
                    // Apply threshold dithering with a 4‑bit palette as an alternative
                    tiffImage.Dither(DitheringMethod.ThresholdDithering, 4, null);
                }
                else
                {
                    Console.Error.WriteLine("Unsupported image type for dithering.");
                    return;
                }

                // Save the dithered image as TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to convert a CorelDRAW (CDR) file to a high‑contrast black‑and‑white TIFF for printing or archival purposes.
 * 2. When you want to reduce file size by applying 1‑bit Floyd‑Steinberg dithering before storing the image as a TIFF.
 * 3. When your workflow requires automated batch processing of CDR graphics into TIFFs with consistent dithering across multiple documents.
 * 4. When you must generate TIFF images compatible with legacy scanners that only accept dithered 1‑bit or 4‑bit palettes.
 * 5. When you are building a .NET application that needs to programmatically apply threshold or Floyd‑Steinberg dithering to raster images and output them as TIFF files.
 */
