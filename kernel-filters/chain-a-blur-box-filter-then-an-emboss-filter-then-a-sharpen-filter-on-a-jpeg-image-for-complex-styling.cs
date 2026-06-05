using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply a blur box filter (kernel size 3)
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetBlurBox(3)));

                // Apply an emboss filter (3x3 emboss kernel)
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Apply a sharpen filter (kernel size 5, sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When creating a stylized product catalog where each JPEG photo needs a soft blur, a subtle emboss texture, and a final sharpen to make details pop for online shoppers.
 * 2. When preparing thumbnail previews for a photography portfolio website and you want to apply a combined blur‑box, emboss, and sharpen effect to give a unique artistic look while keeping the JPEG format.
 * 3. When developing a desktop application that automatically enhances scanned documents by smoothing noise, adding depth with emboss, and improving legibility with sharpening before saving as JPEG.
 * 4. When building an image‑processing pipeline for a social‑media app that applies a three‑step filter chain (blur, emboss, sharpen) to user‑uploaded JPEGs to create eye‑catching visual filters.
 * 5. When implementing a batch‑processing tool in C# that processes a folder of JPEG images, applying a blur box filter, an emboss convolution, and a sharpen filter to achieve a consistent, stylized appearance for marketing materials.
 */