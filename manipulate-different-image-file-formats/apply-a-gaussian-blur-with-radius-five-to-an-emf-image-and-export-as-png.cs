// HOW-TO: Apply Gaussian Blur to EMF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample_blurred.png";

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

            // Load the EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Set up rasterization options for EMF to PNG conversion
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize EMF to a memory stream as PNG
                using (var ms = new MemoryStream())
                {
                    emfImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized PNG image
                    using (Image rasterImage = Image.Load(ms))
                    {
                        var raster = (RasterImage)rasterImage;

                        // Apply Gaussian blur with radius 5 and sigma 4.0
                        raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Save the blurred image as PNG
                        raster.Save(outputPath);
                    }
                }
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
 * 1. When you need to soften vector graphics from a Windows Metafile before displaying them on a web page, you can rasterize the EMF, apply a Gaussian blur, and output a PNG.
 * 2. When generating preview thumbnails of engineering diagrams stored as EMF files, applying a blur can hide sensitive details while still showing the overall layout.
 * 3. When creating blurred background images for UI overlays from EMF assets, you can convert the vector to PNG, blur it, and use the result as a low‑resolution backdrop.
 * 4. When preprocessing EMF logos for print‑ready PDFs that require a soft focus effect, the code lets you apply a radius‑5 Gaussian blur and save the result as a high‑quality PNG.
 * 5. When automating a batch job that converts multiple EMF icons to blurred PNGs for a mobile app’s loading screen, this approach handles rasterization, filtering, and saving in one workflow.
 */
