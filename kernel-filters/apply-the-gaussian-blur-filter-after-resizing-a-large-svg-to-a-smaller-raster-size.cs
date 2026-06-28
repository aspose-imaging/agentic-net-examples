using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\large.svg";
            string resizedPath = @"C:\Images\resized.png";
            string outputPath = @"C:\Images\blurred.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(resizedPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Desired raster size
            int newWidth = 800;
            int newHeight = 600;

            // Load SVG and rasterize to PNG with the new size
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = new Size(newWidth, newHeight)
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(resizedPath, pngOptions);
            }

            // Load the rasterized image
            using (Image rasterImage = Image.Load(resizedPath))
            {
                // Cast to RasterImage to access filtering
                var raster = (RasterImage)rasterImage;

                // Apply Gaussian blur filter (size = 5, sigma = 4.0)
                var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
                raster.Filter(raster.Bounds, blurOptions);

                // Save the final blurred image
                raster.Save(outputPath);
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
 * 1. When generating thumbnail previews of vector logos for a web gallery, a developer can resize the SVG to a smaller PNG and apply a Gaussian blur to soften edges for a subtle background effect.
 * 2. When preparing low‑resolution map tiles from high‑detail SVG diagrams, resizing the SVG and then applying Gaussian blur helps reduce visual noise while keeping the PNG file size suitable for mobile apps.
 * 3. When creating stylized product catalog images where a main photo is overlaid on a blurred SVG background, the code resizes the SVG and adds Gaussian blur to achieve a depth‑of‑field look.
 * 4. When converting large SVG icons into PNG assets for email newsletters, applying a Gaussian blur after resizing ensures smoother gradients and avoids jagged artifacts across different email clients.
 * 5. When generating preview frames for video‑editing software from SVG overlays, a developer can rasterize the SVG to a smaller PNG and use Gaussian blur to simulate motion blur before compositing the frame.
 */