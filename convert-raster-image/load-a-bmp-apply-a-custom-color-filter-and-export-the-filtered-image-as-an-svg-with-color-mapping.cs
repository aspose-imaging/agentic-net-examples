using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel manipulation
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Apply a simple custom color filter:
                // Example: swap red and blue channels for each pixel
                for (int y = 0; y < raster.Height; y++)
                {
                    for (int x = 0; x < raster.Width; x++)
                    {
                        // Get current pixel color
                        Color original = raster.GetPixel(x, y);

                        // Swap red and blue components
                        Color filtered = Color.FromArgb(
                            original.A,
                            original.B, // new Red = original Blue
                            original.G,
                            original.R  // new Blue = original Red
                        );

                        // Set the modified pixel back
                        raster.SetPixel(x, y, filtered);
                    }
                }

                // Save the filtered image as SVG with default options
                SvgOptions svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert legacy BMP graphics to scalable SVG files while applying a custom color transformation such as swapping red and blue channels using Aspose.Imaging for .NET.
 * 2. When an application must preprocess scanned BMP images by adjusting their color channels before embedding them as vector SVG assets in a web page.
 * 3. When a game developer wants to recolor sprite sheets stored as BMPs and export them as SVGs for resolution‑independent rendering in a C# UI.
 * 4. When a reporting tool generates BMP charts that require a specific color filter and then needs to embed the results as SVG diagrams in PDF or HTML outputs.
 * 5. When an automation script processes a batch of BMP files, applies pixel‑level color manipulation, and saves the results as SVG vectors for downstream design workflows.
 */