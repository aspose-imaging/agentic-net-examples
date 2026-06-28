using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter (size = 5, sigma = 4.0)
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply Emboss 3x3 convolution filter
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

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
 * 1. When creating a stylized web icon, a developer can blur the SVG background with a Gaussian blur and then apply an Emboss3x3 filter to add a subtle 3‑D relief before exporting it as a PNG.
 * 2. When generating printable marketing materials, a designer may use this code to soften vector graphics with a Gaussian blur and then emboss the edges to give the logo a tactile appearance in the final raster image.
 * 3. When developing a photo‑editing app that supports vector assets, the code can be used to apply a smooth blur followed by an emboss effect to SVG illustrations, producing a polished, artistic look for user‑generated content.
 * 4. When preparing SVG diagrams for inclusion in a PowerPoint presentation, a developer can chain a Gaussian blur and an Emboss3x3 filter to reduce visual noise and add depth, then save the result as a high‑resolution PNG.
 * 5. When building an automated batch‑processing pipeline for e‑commerce product images, this snippet can be employed to uniformly blur product SVG overlays and emboss them, creating consistent, eye‑catching thumbnails across the catalog.
 */