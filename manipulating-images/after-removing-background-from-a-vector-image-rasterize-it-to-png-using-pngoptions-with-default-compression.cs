using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

public class Program
{
    public static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // Remove background if the image is a vector type
                if (image is VectorImage vectorImage)
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }

                // Configure PNG options with default compression and transparency
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = image.Size
                    }
                };

                // Save the rasterized PNG
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
 * 1. When a web application needs to generate transparent PNG thumbnails from user‑uploaded SVG logos after removing any unwanted background.
 * 2. When an e‑commerce platform wants to convert product vector illustrations into high‑quality PNG images for display on mobile devices while preserving alpha transparency.
 * 3. When a desktop publishing tool automates the preparation of print‑ready assets by stripping backgrounds from SVG icons and rasterizing them to PNG with default compression.
 * 4. When a marketing automation script batch‑processes brand assets, converting SVG graphics to PNG format after background removal for use in email campaigns.
 * 5. When a game development pipeline requires converting vector UI elements into PNG sprites with transparent backgrounds to integrate them into the game engine.
 */