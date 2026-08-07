using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\sample.svg";
            string outputPath = @"c:\temp\sample.GaussianBlur.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur (size = 5, sigma = 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Verify that no pixel channel exceeds 255
                bool exceeds = false;
                for (int y = 0; y < rasterImage.Height && !exceeds; y++)
                {
                    for (int x = 0; x < rasterImage.Width && !exceeds; x++)
                    {
                        var color = rasterImage.GetPixel(x, y);
                        if (color.R > 255 || color.G > 255 || color.B > 255)
                        {
                            exceeds = true;
                        }
                    }
                }

                Console.WriteLine(exceeds
                    ? "Pixel intensity exceeds 255."
                    : "All pixel intensities are within 0-255.");

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
 * 1. When a developer needs to apply a Gaussian blur to an SVG logo and ensure the resulting PNG does not contain any pixel values above the 0‑255 range for safe web display.
 * 2. When a C# application must convert vector graphics to raster format while validating that the blur filter does not cause channel overflow before uploading to a digital asset management system.
 * 3. When building an automated image‑processing pipeline that reads SVG files, applies a GaussianBlurFilterOptions(5,4.0) and verifies pixel intensity limits to prevent color distortion in printed materials.
 * 4. When performing quality‑assurance testing on a graphics‑editing tool that uses Aspose.Imaging to rasterize SVGs, checking that no pixel channel exceeds 255 after applying the blur filter.
 * 5. When creating a batch script that processes a folder of SVG icons, applies Gaussian blur, and confirms all pixel values stay within the 0‑255 range to maintain compatibility with downstream image‑analysis algorithms.
 */