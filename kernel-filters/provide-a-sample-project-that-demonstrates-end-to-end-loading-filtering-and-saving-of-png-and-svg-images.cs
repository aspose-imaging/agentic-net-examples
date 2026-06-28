using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string pngInputPath = @"C:\temp\input.png";
            string pngOutputPath = @"C:\temp\output_grayscale.png";

            string svgInputPath = @"C:\temp\input.svg";
            string svgOutputPath = @"C:\temp\output_from_svg.png";

            // ---------- PNG processing ----------
            // Verify input file exists
            if (!File.Exists(pngInputPath))
            {
                Console.Error.WriteLine($"File not found: {pngInputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

            // Load PNG, convert to grayscale, and save
            using (PngImage pngImage = new PngImage(pngInputPath))
            {
                pngImage.Grayscale();                     // Apply grayscale filter
                pngImage.Save(pngOutputPath);             // Save result
            }

            // ---------- SVG processing ----------
            // Verify SVG input exists
            if (!File.Exists(svgInputPath))
            {
                Console.Error.WriteLine($"File not found: {svgInputPath}");
                return;
            }

            // Ensure SVG output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

            // Load SVG vector image
            using (Image svgImage = Image.Load(svgInputPath))
            {
                // Prepare PNG save options (you can customize as needed)
                PngOptions pngOptions = new PngOptions
                {
                    // Example: enable progressive loading and set compression
                    Progressive = true,
                    CompressionLevel = 9,
                    FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive,
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                    BitDepth = 8
                };

                // Rasterize SVG to PNG using the options
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
 * 1. When a developer needs to convert uploaded PNG photos to grayscale before storing them in a content‑management system.
 * 2. When a web service must generate thumbnail PNGs from user‑provided SVG logos for display on a responsive website.
 * 3. When an automated batch job processes a folder of PNG assets, applying a grayscale filter to meet a brand‑guideline requirement.
 * 4. When an e‑commerce platform converts scalable SVG product illustrations into raster PNG images for email newsletters.
 * 5. When a desktop utility validates the existence of image files, creates missing output directories, and saves processed PNGs to a temporary cache.
 */