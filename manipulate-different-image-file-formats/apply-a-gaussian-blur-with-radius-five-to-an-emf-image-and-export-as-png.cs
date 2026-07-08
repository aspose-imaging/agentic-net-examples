using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string tempPngPath = @"C:\Images\temp.png";
        string outputPath = @"C:\Images\output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image and rasterize it to a temporary PNG
            using (Image emfImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        BackgroundColor = Color.White
                    }
                };

                // Save rasterized PNG to a temporary file
                emfImage.Save(tempPngPath, pngOptions);
            }

            // Load the temporary PNG as a raster image
            using (Image rasterImage = Image.Load(tempPngPath))
            {
                var raster = (RasterImage)rasterImage;

                // Apply Gaussian blur with radius 5 and sigma 4.0
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the blurred image as the final PNG
                raster.Save(outputPath, new PngOptions());
            }

            // Optionally delete the temporary file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When a developer needs to convert a vector EMF diagram into a raster PNG for web display while softening edges with a Gaussian blur of radius five.
 * 2. When an application must generate thumbnail previews of EMF icons and apply a subtle blur to hide proprietary details before saving them as PNG files.
 * 3. When a reporting tool has to embed EMF charts into PDF or HTML output, rasterize them to PNG, and apply a Gaussian blur to achieve a background‑blur effect for visual emphasis.
 * 4. When a batch‑processing script processes a folder of EMF logos, rasterizes each to PNG, and adds a Gaussian blur to meet brand‑guideline styling requirements.
 * 5. When a C# service receives user‑uploaded EMF drawings, needs to sanitize them by rasterizing to PNG and applying a radius‑5 Gaussian blur to reduce sharp vector artifacts before storing the image.
 */