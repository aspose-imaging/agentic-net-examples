// HOW-TO: Dither TIFF Image and Apply Gaussian Blur Then Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiff = (TiffImage)image;

                // Dither the image using Floyd‑Steinberg dithering with a 1‑bit palette
                tiff.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                tiff.Filter(tiff.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as PNG
                tiff.Save(outputPath, new PngOptions());
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
 * 1. When you need to convert a high‑resolution scanned TIFF document into a web‑friendly PNG while reducing file size with 1‑bit dithering and smoothing edges using a Gaussian blur.
 * 2. When preparing archival images for low‑color‑depth devices, applying Floyd‑Steinberg dithering and blur to improve visual quality before saving as PNG in a C# application.
 * 3. When generating thumbnails of TIFF graphics that require both binary dithering for contrast and a soft blur effect for a polished look.
 * 4. When processing medical or engineering TIFF scans to emphasize structures by dithering and then applying a Gaussian blur before exporting to PNG for inclusion in reports.
 * 5. When building an automated image pipeline that ingests TIFF files, applies dithering and Gaussian blur to meet branding guidelines, and outputs PNGs for use on websites.
 */
