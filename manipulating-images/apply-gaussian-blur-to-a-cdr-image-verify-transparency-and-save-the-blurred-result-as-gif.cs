// HOW-TO: Apply Gaussian Blur to CDR Image, Check Transparency, Save as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_blurred.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply raster filters
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("Failed to convert CDR image to raster format.");
                    return;
                }

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Verify transparency: check if any pixel has alpha < 255
                bool hasTransparency = false;
                int[] argbPixels = rasterImage.GetDefaultArgb32Pixels(rasterImage.Bounds);
                foreach (int pixel in argbPixels)
                {
                    int alpha = (pixel >> 24) & 0xFF;
                    if (alpha < 255)
                    {
                        hasTransparency = true;
                        break;
                    }
                }

                Console.WriteLine(hasTransparency
                    ? "The image contains transparent pixels."
                    : "The image does not contain transparent pixels.");

                // Save the blurred image as GIF with palette correction
                var gifOptions = new GifOptions
                {
                    DoPaletteCorrection = true
                };

                rasterImage.Save(outputPath, gifOptions);
                Console.WriteLine($"Blurred GIF saved to: {outputPath}");
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
 * 1. When you need to programmatically soften a CorelDRAW (CDR) illustration while preserving any transparent areas before converting it to a GIF for web use.
 * 2. When you must verify that a CDR file contains alpha channel data after processing, ensuring that the resulting GIF will retain intended transparency effects.
 * 3. When automating a batch workflow that converts multiple CDR designs into blurred GIF thumbnails for preview galleries in a .NET application.
 * 4. When integrating image preprocessing steps such as Gaussian blur into a C# service that prepares graphics for email newsletters, requiring GIF output with correct transparency handling.
 * 5. When building a desktop tool that allows users to apply custom blur radius and sigma values to vector drawings, then export the result as a GIF while confirming transparent pixel integrity.
 */
