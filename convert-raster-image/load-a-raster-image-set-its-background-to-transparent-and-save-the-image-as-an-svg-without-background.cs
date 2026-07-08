using System;
using System.IO;
using Aspose.Imaging;
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
                // Prepare SVG save options with transparent background
                var svgOptions = new SvgOptions();

                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Aspose.Imaging.Color.Transparent // make background transparent
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When a web developer needs to convert PNG logos with solid backgrounds into scalable SVG icons with a transparent background for responsive UI design.
 * 2. When a desktop application generates chart screenshots and must embed them in vector‑based reports without background artifacts.
 * 3. When an e‑commerce platform wants to transform product photos into SVG thumbnails that can be overlaid on different colored backgrounds.
 * 4. When a mobile app processes user‑uploaded images and needs to create transparent SVG assets for custom stickers or emojis.
 * 5. When a GIS tool rasterizes map tiles and saves them as SVG files with no background to overlay on other map layers.
 */