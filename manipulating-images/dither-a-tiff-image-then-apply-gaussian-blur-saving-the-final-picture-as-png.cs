using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.png";

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
                TiffImage tiffImage = (TiffImage)image;

                // Dither the image (Floyd‑Steinberg, 1‑bit palette)
                tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                // Apply Gaussian blur (radius 5, sigma 4.0)
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the result as PNG
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
 * 1. When a developer needs to convert a large scanned TIFF file into a lightweight PNG for web display, they can dither it to a 1‑bit palette and apply a Gaussian blur to reduce visual noise.
 * 2. When preparing archival TIFF images for printing on low‑resolution devices, dithering with Floyd‑Steinberg and adding a blur helps preserve readability while minimizing banding.
 * 3. When generating thumbnail previews of multi‑page TIFF documents, applying dithering and a Gaussian blur creates a smooth, high‑contrast PNG that loads quickly in browsers.
 * 4. When integrating scanned forms into a C# application that requires PNG output, the code can dither the TIFF to simplify colors and blur it to mask scanner artifacts before saving.
 * 5. When automating a batch process that converts medical imaging TIFFs to PNGs for electronic health records, dithering and Gaussian blur ensure consistent visual quality across varied image sources.
 */