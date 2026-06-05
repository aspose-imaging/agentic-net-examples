using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\large.svg";
        string outputPath = @"C:\Images\blurred.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage for vector operations
                SvgImage svgImage = (SvgImage)image;

                // Determine new raster size (e.g., half of original)
                int newWidth = svgImage.Width / 2;
                int newHeight = svgImage.Height / 2;

                // Resize the SVG while preserving aspect ratio
                svgImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Prepare temporary raster file path
                string tempPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

                // Set up rasterization options for PNG output
                var pngOptions = new PngOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save the resized SVG as a raster PNG (temporary file)
                svgImage.Save(tempPath, pngOptions);

                // Load the raster PNG to apply Gaussian blur
                using (Image rasterImage = Image.Load(tempPath))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply Gaussian blur filter to the entire image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the final blurred image to the desired output path
                    raster.Save(outputPath);
                }

                // Clean up temporary file
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
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
 * 1. When a web developer needs to generate low‑resolution thumbnail PNGs from high‑detail SVG icons and add a subtle Gaussian blur to soften edges for a modern UI.
 * 2. When an e‑commerce platform must convert large product vector illustrations into smaller raster images for email newsletters while applying blur to meet brand‑style guidelines.
 * 3. When a mobile app creates preview images of scalable vector maps, resizing them to fit screen dimensions and using Gaussian blur to create a background overlay effect.
 * 4. When a reporting tool automatically produces chart snapshots from SVG diagrams, downsizing them for PDF reports and applying blur to de‑emphasize watermarks.
 * 5. When a game developer prepares UI assets by rasterizing detailed SVG artwork to PNG sprites at reduced size and adding Gaussian blur to achieve a motion‑blur visual cue.
 */