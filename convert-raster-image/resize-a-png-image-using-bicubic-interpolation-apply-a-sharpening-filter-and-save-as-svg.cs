using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.svg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize using bicubic (cubic convolution) interpolation
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Apply sharpening filter
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the result as SVG
                image.Save(outputPath, new SvgOptions());
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
 * 1. When a developer needs to double the resolution of a PNG logo for high‑DPI displays while preserving smooth edges using bicubic interpolation and then sharpen it before converting to scalable SVG for responsive web design.
 * 2. When an e‑commerce platform must generate crisp, scalable product icons from original PNG thumbnails, resizing them with cubic convolution and applying a sharpening filter to maintain detail in the SVG output.
 * 3. When a mobile app creates printable vector assets from user‑uploaded PNG graphics, requiring image enlargement, edge enhancement, and conversion to SVG to support infinite scaling without loss of quality.
 * 4. When a content management system automates the preparation of marketing banners by enlarging PNG images, sharpening the result, and saving as SVG to reduce file size and enable CSS styling.
 * 5. When a developer builds a batch processing tool that upgrades legacy PNG assets, applies bicubic resizing and sharpening, and exports them as SVG files for use in modern UI frameworks.
 */