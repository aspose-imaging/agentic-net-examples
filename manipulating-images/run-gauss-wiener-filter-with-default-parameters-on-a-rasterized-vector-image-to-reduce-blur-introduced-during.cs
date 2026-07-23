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
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image (vector or raster) and cast to RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gauss‑Wiener filter with default size 5 and sigma 4.0
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

                // Save the filtered image
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
 * 1. When a developer needs to convert an SVG vector graphic to a PNG raster image and automatically reduce conversion blur using the Gauss‑Wiener filter with default parameters.
 * 2. When a C# application must load a vector file, rasterize it, and improve visual sharpness before saving it for web display or reporting.
 * 3. When an automated image‑processing pipeline processes batch SVG assets and requires a simple way to apply noise‑reduction and de‑blurring without manually tuning filter size or sigma.
 * 4. When a developer is building a document‑generation tool that embeds vector diagrams as PNGs and wants to ensure the output looks crisp by applying the built‑in Gauss‑Wiener filter in Aspose.Imaging.
 * 5. When troubleshooting image quality issues after rasterizing vector artwork, a programmer can use this code to quickly test the effect of the default Gauss‑Wiener filter on the resulting PNG file.
 */