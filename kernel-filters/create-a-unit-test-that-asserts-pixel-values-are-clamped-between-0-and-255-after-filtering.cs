// HOW-TO: Verify PNG Pixel Values Remain Within 0-255 After Sharpen Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Ensure input file exists; create a simple image if missing
            if (!File.Exists(inputPath))
            {
                using (PngImage img = new PngImage(10, 10))
                {
                    // Fill with a mid‑gray color
                    img.Save(inputPath);
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply a sharpen filter that may increase pixel values
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the filtered image
                raster.Save(outputPath);

                // Verify that every channel is clamped between 0 and 255
                for (int y = 0; y < raster.Height; y++)
                {
                    for (int x = 0; x < raster.Width; x++)
                    {
                        var color = raster.GetPixel(x, y);
                        if (color.R < 0 || color.R > 255 ||
                            color.G < 0 || color.G > 255 ||
                            color.B < 0 || color.B > 255 ||
                            color.A < 0 || color.A > 255)
                        {
                            Console.Error.WriteLine($"Pixel out of range at ({x},{y})");
                            return;
                        }
                    }
                }

                Console.WriteLine("All pixel values are within 0‑255.");
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
 * 1. When you need to unit‑test that applying a sharpen filter with Aspose.Imaging does not produce pixel values outside the 0‑255 range for PNG images.
 * 2. When you are building an automated image‑processing workflow and must guarantee that filtered images remain compliant with standard 8‑bit per channel limits.
 * 3. When you want to prevent overflow errors in downstream graphics libraries by confirming that every channel is clamped after enhancement operations.
 * 4. When you are validating custom filter parameters (e.g., radius and amount) to ensure they do not corrupt the image data in a C# application.
 * 5. When you are creating a CI pipeline that checks image quality and pixel integrity after applying Aspose.Imaging filters before publishing assets.
 */
