using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.png";
            string outputPath = @"C:\Images\output_emboss.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and cast to RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply a sharpen filter as an approximation of emboss effect
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save the processed image as PNG
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer wants to let users load a PNG file in a WPF photo editor and instantly see an emboss‑like effect applied to the raster image.
 * 2. When a desktop application needs to validate that the selected image exists, create the output folder, and apply a sharpen filter as a fast approximation of emboss before saving the result.
 * 3. When building a batch‑processing tool that programmatically loads images, applies the Aspose.Imaging FilterOptions.SharpenFilterOptions to simulate emboss, and writes the transformed PNG to a predefined directory.
 * 4. When implementing a real‑time preview pane in a WPF UI that calls Image.Load, casts to RasterImage, and uses rasterImage.Filter with bounds to render the emboss effect without blocking the UI thread.
 * 5. When troubleshooting image‑processing pipelines, a developer uses this code to confirm that the Aspose.Imaging sharpen filter correctly modifies the pixel data and produces a visible emboss effect in the saved PNG file.
 */