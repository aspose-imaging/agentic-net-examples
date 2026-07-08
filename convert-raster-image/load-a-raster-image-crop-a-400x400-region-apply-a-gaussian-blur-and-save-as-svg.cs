using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for raster operations
                RasterImage rasterImage = (RasterImage)image;

                // Define a 400x400 crop rectangle (top-left corner)
                Rectangle cropRect = new Rectangle(0, 0, 400, 400);
                rasterImage.Crop(cropRect);

                // Apply Gaussian blur filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare SVG rasterization options matching the cropped image size
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = rasterImage.Size
                };

                // Set up SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the processed image as SVG
                rasterImage.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to generate a scalable SVG thumbnail from a high‑resolution PNG by cropping a 400 × 400 region and applying a Gaussian blur for a smooth preview.
 * 2. When an e‑commerce platform wants to create lightweight SVG icons from product photos, extracting a central 400 × 400 area and softening edges with a blur filter using C# and Aspose.Imaging.
 * 3. When a web‑designer automates the conversion of raster screenshots into SVG assets, preserving only the top‑left 400 × 400 pixels and adding a blur effect to reduce visual noise.
 * 4. When a reporting tool must embed a blurred, cropped snapshot of a chart as an SVG element to ensure resolution‑independent rendering in PDFs generated with .NET.
 * 5. When a mobile app backend processes user‑uploaded images, cropping them to a fixed 400 × 400 size, applying a Gaussian blur for privacy, and storing the result as an SVG for scalable display.
 */