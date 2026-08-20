// HOW-TO: Crop Image, Apply Gaussian Blur, and Save as SVG in C# (Aspose.Imaging for .NET)
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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for raster operations
                RasterImage rasterImage = (RasterImage)image;

                // Crop a 400x400 region from the top-left corner
                rasterImage.Crop(new Rectangle(0, 0, 400, 400));

                // Apply Gaussian blur to the entire image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as SVG
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
 * 1. When you need to generate a vector‑based preview of a cropped portion of a raster photo with a soft blur effect for web thumbnails.
 * 2. When you want to preprocess a large PNG by extracting a 400×400 area, applying a Gaussian blur, and exporting it as SVG for scalable UI assets.
 * 3. When creating responsive graphics where a blurred, cropped raster region must be converted to SVG to retain quality at any screen size.
 * 4. When automating a pipeline that extracts a specific region from scanned images, smooths it with a blur, and stores the result in a lightweight vector format.
 * 5. When building a C# tool that prepares image assets for print or digital publishing by cropping, blurring, and converting them to SVG for easy editing.
 */
