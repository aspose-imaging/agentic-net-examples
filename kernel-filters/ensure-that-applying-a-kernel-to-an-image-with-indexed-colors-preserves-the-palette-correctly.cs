// HOW-TO: Sharpen Indexed PNG With Convolution Filter While Preserving Palette In C# (Aspose.Imaging for .NET)
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

                // Preserve original palette (or generate a close palette)
                var palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette(raster, 256, Aspose.Imaging.PaletteMiningMethod.Histogram);

                // Define a 3x3 sharpening kernel
                double[,] kernel = new double[,]
                {
                    { 0, -1,  0 },
                    { -1, 5, -1 },
                    { 0, -1,  0 }
                };

                // Apply convolution filter using the kernel
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                // Save as indexed PNG preserving the palette
                PngOptions saveOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = palette,
                    CompressionLevel = 9,
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
 * 1. When you need to sharpen a PNG or GIF that uses an indexed color palette without altering the original colors.
 * 2. When you want to apply a custom 3×3 convolution kernel to an indexed image and keep the file size low by saving as an indexed PNG with compression.
 * 3. When processing legacy graphics that rely on a specific palette and require post‑processing such as sharpening before publishing on a website.
 * 4. When building a batch image‑processing tool that must maintain exact palette mapping after applying filters to PNG sprites.
 * 5. When generating high‑quality, progressive UI assets where the palette must stay consistent after applying a sharpening filter.
 */
