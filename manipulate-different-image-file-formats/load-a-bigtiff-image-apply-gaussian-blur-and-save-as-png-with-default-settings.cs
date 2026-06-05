using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\big.tif";
            string outputPath = @"C:\Images\blurred.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the BigTIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the result as PNG with default settings
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
 * 1. When a developer needs to convert a large scientific BigTIFF microscopy image into a smaller PNG for web preview while applying a Gaussian blur to reduce noise.
 * 2. When an application must process high‑resolution satellite imagery stored as BigTIFF, smooth it with a Gaussian blur, and output a PNG for inclusion in a GIS report.
 * 3. When a medical imaging system requires loading a BigTIFF pathology slide, applying a blur filter to anonymize patient details, and saving the result as a PNG for secure sharing.
 * 4. When a batch‑processing tool has to read massive scanned documents in BigTIFF format, soften the background with a Gaussian blur, and generate PNG thumbnails for a document management portal.
 * 5. When a C# service needs to read a BigTIFF raster, apply a radius‑5 Gaussian blur to improve visual quality, and store the processed image as a PNG using default Aspose.Imaging settings.
 */