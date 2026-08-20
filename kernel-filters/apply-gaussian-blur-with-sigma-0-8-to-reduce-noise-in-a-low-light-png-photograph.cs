// HOW-TO: Apply Gaussian Blur With Sigma 0.8 To PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\lowlight.png";
        string outputPath = @"C:\Images\lowlight_blur.png";

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with kernel size 5 and sigma 0.8 to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(5, 0.8)
                );

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
 * 1. When you need to reduce noise in low‑light PNG photos before further analysis or display.
 * 2. When preparing PNG assets for a web gallery and want a subtle blur to smooth grainy images.
 * 3. When cleaning up scanned PNG documents taken in dim conditions to improve readability.
 * 4. When preprocessing images for a computer‑vision pipeline that requires less high‑frequency noise.
 * 5. When automating batch processing of PNG screenshots captured at night to enhance visual quality.
 */
