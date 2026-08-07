using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "templates/sample.png";
        string outputPath = "output/sample_blur.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply a 5×5 blur filter.
                // Aspose.Imaging does not provide a direct box‑blur filter, so we use a Gaussian blur
                // with a radius of 5 (which approximates a 5×5 blur kernel).
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

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
 * 1. When generating thumbnail previews for a web gallery, a developer can load PNG files and apply a 5×5 Gaussian blur to create a soft background effect before overlaying text.
 * 2. When preparing product images for an e‑commerce site, a developer may need to blur sensitive details in PNG assets using Aspose.Imaging’s GaussianBlurFilterOptions to comply with privacy regulations.
 * 3. When building a desktop application that adds a subtle vignette to user‑uploaded PNG screenshots, a developer can use this code to apply a 5×5 blur filter as part of the image‑enhancement pipeline.
 * 4. When automating the creation of low‑resolution placeholder images for mobile apps, a developer can load high‑quality PNGs and apply a 5×5 blur to reduce visual noise while preserving overall composition.
 * 5. When implementing a C# batch‑processing tool that sanitizes PNG logos by blurring edges before printing, a developer can use the raster image filter to achieve a consistent 5×5 blur across all files.
 */