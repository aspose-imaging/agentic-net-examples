using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\vector.svg";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector drawing (e.g., SVG). Aspose.Imaging renders it to a raster image.
            using (Image loadedImage = Image.Load(inputPath))
            {
                // Cast to RasterImage for further processing
                using (RasterImage rasterImage = (RasterImage)loadedImage)
                {
                    int width = rasterImage.Width;
                    int height = rasterImage.Height;

                    // Create an opacity mask (semi‑transparent white mask)
                    using (PngImage maskImage = new PngImage(width, height))
                    {
                        // Fill the mask with 50% opacity (alpha = 128)
                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                maskImage.SetPixel(x, y, Color.FromArgb(128, 255, 255, 255));
                            }
                        }

                        // Prepare masking options
                        var maskingOptions = new MaskingOptions
                        {
                            Decompose = false,
                            BackgroundReplacementColor = Color.Transparent,
                            ExportOptions = new PngOptions
                            {
                                ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha
                            }
                        };

                        // Apply the opacity mask to the raster image
                        ImageMasking.ApplyMask(rasterImage, maskImage, maskingOptions);

                        // Save the result as PNG with alpha channel
                        rasterImage.Save(outputPath, maskingOptions.ExportOptions);
                    }
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
 * 1. When a web developer uses Aspose.Imaging for .NET to convert an SVG logo into a semi‑transparent PNG with an alpha channel for overlay on dynamic page backgrounds.
 * 2. When a UI designer needs to rasterize vector icons (SVG) with a 50 % opacity mask and export them as PNG files for mobile app splash screens using C#.
 * 3. When a reporting engine must embed vector diagrams by loading SVG, applying an opacity mask, and saving as PNG with transparency for inclusion in PDF reports.
 * 4. When an e‑commerce platform processes product illustrations by loading SVG files, applying a uniform opacity mask, and exporting PNG images with alpha channel before uploading to a CDN.
 * 5. When a game developer creates HUD elements by rendering SVG assets, applying a custom opacity mask, and saving them as PNGs with alpha transparency for real‑time rendering.
 */