using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input.svg";
            string outputPath = "output.bmp";

            // Verify that the input SVG exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure BMP save options with an indexed (8‑bit) palette
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    // Use a simple 8‑bit grayscale palette as the indexed palette
                    Palette = Aspose.Imaging.ColorPaletteHelper.Create8BitGrayscale(false),
                    // Set resolution (optional, but common)
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                    // Provide rasterization options for the vector SVG source
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save the image as BMP using the defined options
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to use Aspose.Imaging BmpOptions to convert SVG logos into 8‑bit BMP files for a legacy inventory‑management system that only accepts indexed‑color BMP images.
 * 2. When a developer wants to employ BmpOptions with an 8‑bit grayscale palette to generate low‑size BMP assets from SVG graphics for a game engine that requires indexed textures for performance.
 * 3. When a developer must rasterize SVG diagrams into BMP format at 96 dpi using SvgRasterizationOptions because a legacy reporting tool cannot render vector files.
 * 4. When a developer is preparing BMP icons with a fixed 8‑bit palette via BmpOptions for a Windows desktop application that relies on system‑theme color matching.
 * 5. When a developer needs to batch‑process SVG assets into BMP files using Aspose.Imaging’s BmpOptions and a custom indexed palette to satisfy a hardware device that only supports indexed BMP images.
 */