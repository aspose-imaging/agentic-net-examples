using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\sample.png";
            string outputPath = "output\\result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image and cast to RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Compute original average luminance
                int[] originalPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double originalLuminance = originalPixels
                    .Select(p =>
                    {
                        int r = (p >> 16) & 0xFF;
                        int g = (p >> 8) & 0xFF;
                        int b = p & 0xFF;
                        return 0.299 * r + 0.587 * g + 0.114 * b;
                    })
                    .Average();

                // Apply custom Gaussian blur (radius 5, sigma 4.0)
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Compute luminance after blur
                int[] blurredPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double blurredLuminance = blurredPixels
                    .Select(p =>
                    {
                        int r = (p >> 16) & 0xFF;
                        int g = (p >> 8) & 0xFF;
                        int b = p & 0xFF;
                        return 0.299 * r + 0.587 * g + 0.114 * b;
                    })
                    .Average();

                // Adjust brightness to restore original luminance
                int brightnessAdjustment = (int)Math.Round(originalLuminance - blurredLuminance);
                raster.AdjustBrightness(brightnessAdjustment);

                // Save the processed image as PNG
                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to verify that applying a Gaussian blur to PNG assets for a web gallery does not unintentionally darken or brighten the images, they can use this code to compare average luminance before and after the filter.
 * 2. When preparing medical imaging scans in DICOM format for machine‑learning analysis, a programmer can employ this routine to ensure that the Gaussian smoothing step preserves the overall brightness of each slice.
 * 3. When building an automated photo‑editing pipeline in C# that applies custom blur effects to JPEG thumbnails, the code helps confirm that the blur maintains consistent luminance across all generated thumbnails.
 * 4. When integrating Aspose.Imaging into a desktop application that normalizes scanned documents before OCR, developers can measure the luminance change caused by the Gaussian kernel to guarantee legible text contrast.
 * 5. When creating a game asset workflow that blurs sprite PNGs for motion‑blur effects, this snippet lets artists and developers quickly check that the blur does not alter the perceived brightness, keeping visual consistency across frames.
 */