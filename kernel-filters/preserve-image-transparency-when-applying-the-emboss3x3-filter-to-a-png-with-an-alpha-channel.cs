using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply Emboss3x3 filter while preserving alpha channel
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                // Save the result as PNG with alpha channel preserved
                PngOptions saveOptions = new PngOptions
                {
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                    CompressionLevel = 9,
                    FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive,
                    Progressive = true
                };

                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to add an emboss effect to a PNG logo while keeping its transparent background intact for use on web pages.
 * 2. When an e‑commerce platform wants to generate stylized product thumbnails from PNG images with alpha channels without losing the cut‑out shapes.
 * 3. When a mobile app processes user‑uploaded PNG stickers, applying a 3×3 emboss filter while preserving the sticker’s transparency for overlaying on photos.
 * 4. When a game UI pipeline requires converting PNG assets with alpha to an embossed style for hover states without flattening the alpha channel.
 * 5. When an automated batch job must apply a convolution emboss filter to PNG icons and save them with truecolor with alpha to maintain crisp edges in UI themes.
 */