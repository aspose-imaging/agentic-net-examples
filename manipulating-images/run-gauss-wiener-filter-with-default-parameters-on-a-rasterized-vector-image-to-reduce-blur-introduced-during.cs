using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\vectorized.png";
        string outputPath = @"C:\Images\output\vectorized.GaussWiener.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gauss‑Wiener filter with default parameters
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions());

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
 * 1. When a C# application converts a high‑resolution SVG or AI file to a PNG raster image and the conversion introduces unwanted blur, the developer can run the Gauss‑Wiener filter with default parameters to restore sharpness before saving the file.
 * 2. When preparing rasterized vector graphics for optical character recognition (OCR) in a .NET workflow, applying the Gauss‑Wiener filter helps reduce blur caused by rasterization, improving text extraction accuracy.
 * 3. When generating printable PDFs from vector drawings that are first rasterized to PNG, a developer can use this code to de‑blur the image so that printed output retains crisp edges.
 * 4. When serving rasterized icons or UI assets on a website, a C# service can apply the Gauss‑Wiener filter after conversion to PNG to ensure the images look sharp on high‑DPI screens.
 * 5. When archiving raster versions of vector artwork in a digital asset management system, applying the Gauss‑Wiener filter during the C# import process removes conversion blur, preserving visual quality for future retrieval.
 */