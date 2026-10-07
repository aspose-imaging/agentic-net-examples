// HOW-TO: Convert SVG to Grayscale PNG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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
                // Rasterize the vector image to a raster image
                using (RasterImage rasterImage = (RasterImage)image)
                {
                    // Apply grayscale conversion
                    rasterImage.Grayscale();

                    // Prepare PNG save options (optional: enforce grayscale palette)
                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.Grayscale
                    };

                    // Save the result as PNG
                    rasterImage.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a black‑and‑white preview of a vector logo stored as SVG for a web thumbnail.
 * 2. When a reporting tool requires all chart images in grayscale PNG to match a printed report’s style.
 * 3. When an e‑commerce platform must convert user‑uploaded SVG icons to grayscale PNG for consistent UI theming.
 * 4. When a batch job processes SVG assets and stores them as grayscale PNG files to reduce file size for mobile devices.
 * 5. When a document generation system needs to embed SVG diagrams as grayscale PNGs to ensure compatibility with PDF viewers that only support raster images.
 */
