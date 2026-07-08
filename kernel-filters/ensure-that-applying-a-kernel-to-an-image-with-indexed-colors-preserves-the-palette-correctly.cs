using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette(raster, 256, Aspose.Imaging.PaletteMiningMethod.Histogram)
                };

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
 * 1. When a developer needs to sharpen a PNG image that uses an indexed color palette—such as a game sprite sheet—while preserving the original palette to avoid color distortion.
 * 2. When processing scanned documents saved as indexed PNGs and applying an edge‑enhancement kernel without converting the image to true color, ensuring the file size remains low.
 * 3. When creating thumbnail previews of icon sets stored in indexed PNG format and applying a convolution filter to improve visual clarity while keeping the palette consistent for UI theming.
 * 4. When performing batch image processing on web‑optimized PNG graphics that rely on a limited palette, and the developer must apply a custom filter without losing the exact palette mapping.
 * 5. When integrating Aspose.Imaging into a C# application that modifies legacy PNG assets with indexed colors, applying a sharpening kernel and then saving the result with a regenerated palette to maintain compatibility with older browsers.
 */