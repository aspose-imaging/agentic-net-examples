using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage for TIFF-specific operations
                var tiffImage = (Aspose.Imaging.FileFormats.Tiff.TiffImage)image;

                // Apply Floyd‑Steinberg dithering with 1‑bit palette
                tiffImage.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1);

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                tiffImage.Filter(
                    tiffImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as PNG
                var pngOptions = new PngOptions();
                tiffImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert a high‑resolution scanned TIFF document to a web‑friendly PNG while reducing file size with 1‑bit Floyd‑Steinberg dithering and smoothing edges using a Gaussian blur.
 * 2. When an application must prepare archival TIFF images for printing on low‑resolution printers by dithering to a binary palette and applying blur to remove speckle noise before saving as PNG.
 * 3. When a batch‑processing tool has to transform medical imaging TIFF files into PNG thumbnails, using dithering to preserve contrast and Gaussian blur to soften artifacts.
 * 4. When a graphics pipeline requires converting multi‑page TIFF pages to PNG sprites, applying Floyd‑Steinberg dithering for monochrome styling and a Gaussian blur for a subtle vignette effect.
 * 5. When a developer is building a document‑to‑web service that needs to serve TIFF scans as PNGs with reduced color depth and a smooth blur filter to improve visual consistency across browsers.
 */