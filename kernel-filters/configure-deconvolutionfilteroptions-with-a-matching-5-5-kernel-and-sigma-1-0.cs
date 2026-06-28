using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply Deconvolution filter with 5x5 kernel and sigma 1.0
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 1.0)
                );

                // Save the result as PNG
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to restore sharpness in a blurred PNG photograph by applying a 5×5 deconvolution filter with sigma 1.0 using Aspose.Imaging in C#.
 * 2. When a C# application must automatically enhance scanned documents saved as PNG files by reducing motion blur before OCR processing.
 * 3. When an image‑processing service requires batch deblurring of PNG assets uploaded by users, using a fixed 5×5 kernel and sigma 1.0 for consistent results.
 * 4. When a developer wants to integrate a simple deconvolution step into a .NET workflow that loads an image, applies a Gauss‑Wiener filter, and saves the cleaned output as PNG.
 * 5. When a desktop utility needs to improve the visual quality of low‑light PNG images by applying a 5×5 deconvolution filter with sigma 1.0 without manually adjusting parameters.
 */