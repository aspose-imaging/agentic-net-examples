using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\test.svg";
        string outputPath = @"C:\temp\test.output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image from file
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Configure rasterization options (dimensions, background, etc.)
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    // Use the original SVG size as the page size
                    PageSize = svgImage.Size,
                    // Example: reduce size to 50% (optional)
                    ScaleX = 0.5f,
                    ScaleY = 0.5f,
                    // Optional: set background color
                    BackgroundColor = Color.White,
                    // Optional: improve quality
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                // Set up PNG save options and attach rasterization options
                PngOptions saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image to PNG
                svgImage.Save(outputPath, saveOptions);
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded SVG logos as PNG files with a reduced size for faster page loading.
 * 2. When an e‑commerce platform must convert product vector illustrations (SVG) into high‑resolution PNG images for printable catalogs while preserving background color and anti‑aliasing.
 * 3. When a reporting tool has to embed SVG charts into PDF reports that only support raster images, requiring on‑the‑fly rasterization to PNG with specific scaling.
 * 4. When a desktop utility processes a batch of SVG icons, scaling them to 50 % and saving them as PNGs for use in low‑resolution mobile UI assets.
 * 5. When a CI/CD pipeline validates that SVG assets render correctly by programmatically rasterizing them to PNG with a white background and checking the output dimensions.
 */