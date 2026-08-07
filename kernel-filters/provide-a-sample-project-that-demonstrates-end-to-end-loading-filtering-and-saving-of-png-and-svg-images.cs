using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string pngInputPath = @"C:\temp\sample.png";
        string pngOutputPath = @"C:\temp\sample.grayscale.png";

        string svgInputPath = @"C:\temp\sample.svg";
        string svgOutputPath = @"C:\temp\sample_converted.png";

        try
        {
            // ---------- PNG processing ----------
            if (!File.Exists(pngInputPath))
            {
                Console.Error.WriteLine($"File not found: {pngInputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

            // Load PNG, apply grayscale filter, and save
            using (PngImage pngImage = new PngImage(pngInputPath))
            {
                pngImage.Grayscale();
                pngImage.Save(pngOutputPath);
            }

            // ---------- SVG processing ----------
            if (!File.Exists(svgInputPath))
            {
                Console.Error.WriteLine($"File not found: {svgInputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

            // Load SVG (vector image) and rasterize to PNG
            using (Image svgImage = Image.Load(svgInputPath))
            {
                // Configure PNG save options (optional customizations)
                var pngOptions = new PngOptions
                {
                    // Example: enable progressive loading
                    Progressive = true,
                    // Example: set maximum compression
                    CompressionLevel = 9,
                    // Example: use adaptive filter
                    FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive
                };

                // Save the rasterized image as PNG
                svgImage.Save(svgOutputPath, pngOptions);
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
 * 1. When a developer needs to convert a color PNG file to a grayscale PNG for reduced file size or printing consistency, they can use Aspose.Imaging to load the PNG, apply the Grayscale filter, and save the result.
 * 2. When a web application must display user‑uploaded SVG graphics as raster PNG thumbnails, the code can load the SVG, rasterize it with PngOptions, and output a PNG file.
 * 3. When an automated batch job processes a folder of mixed PNG and SVG assets and must ensure all images are stored in a uniform PNG format with specific compression settings, this sample shows how to load, filter, and save each image type.
 * 4. When a desktop utility needs to guarantee that output directories exist before writing processed images, the example demonstrates using Directory.CreateDirectory together with Aspose.Imaging image loading and saving.
 * 5. When a developer wants to enable progressive PNG loading and maximum compression while converting vector SVGs to raster PNGs, the code illustrates configuring PngOptions such as Progressive, CompressionLevel, and FilterType.
 */