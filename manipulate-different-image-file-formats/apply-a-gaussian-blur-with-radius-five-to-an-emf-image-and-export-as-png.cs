using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to allow filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(5, 4.0));

                // Prepare PNG save options with rasterization settings for vector source
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = rasterImage.Size
                    }
                };

                // Save the processed image as PNG
                rasterImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to soften the edges of a vector‑based EMF logo before embedding it in a web page, they can apply a Gaussian blur with radius five and save the result as a PNG for fast loading.
 * 2. When converting legacy EMF diagrams to raster PNG thumbnails for a document management system, applying a Gaussian blur helps reduce visual noise and creates a smoother preview.
 * 3. When preparing EMF‑generated charts for inclusion in a PowerPoint slide deck, a developer may blur the chart background to emphasize overlaid text and then export the image as PNG using Aspose.Imaging for .NET.
 * 4. When automating the creation of blurred watermarks from EMF graphics for PDF reports, the code can rasterize the vector, apply a radius‑5 Gaussian blur, and output a PNG that preserves transparency.
 * 5. When building a batch processing tool that normalizes the appearance of EMF icons by smoothing sharp lines before storing them as PNG assets, developers can use this C# snippet to apply the blur and handle file I/O safely.
 */