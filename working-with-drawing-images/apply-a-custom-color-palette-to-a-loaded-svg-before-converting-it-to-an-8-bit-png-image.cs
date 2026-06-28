using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

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
                // Cast to SvgImage to access SetPalette
                SvgImage svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not an SVG.");
                    return;
                }

                // Create a custom 8‑bit palette (example uses the default 8‑bit palette)
                IColorPalette palette = ColorPaletteHelper.Create8Bit();

                // Apply the palette to the SVG; updateColors = true to remap existing colors
                svgImage.SetPalette(palette, true);

                // Configure PNG options for indexed (8‑bit) output
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = palette
                };

                // Save the image as an 8‑bit PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a web application must generate low‑size thumbnails from user‑uploaded SVG icons by applying a custom 8‑bit color palette before saving them as indexed PNGs for faster page loads.
 * 2. When a desktop tool needs to convert corporate brand SVG logos into 8‑bit PNG assets that match a predefined palette for consistent printing across legacy printers.
 * 3. When an e‑learning platform wants to reduce bandwidth by remapping SVG illustrations to a limited color set and exporting them as indexed PNG files for mobile devices.
 * 4. When a game developer is preparing sprite sheets from vector SVG artwork and must enforce a specific 256‑color palette to meet the engine’s texture memory constraints.
 * 5. When an automated batch process must validate that an SVG file is correctly loaded, apply a custom palette, and output an 8‑bit PNG for archival in a content‑management system.
 */