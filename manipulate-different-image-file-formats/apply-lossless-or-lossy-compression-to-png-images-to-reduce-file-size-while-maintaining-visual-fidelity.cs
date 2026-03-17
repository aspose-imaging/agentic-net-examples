using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output_compressed.png";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for palette generation
            RasterImage raster = image as RasterImage;

            // Configure PNG compression options
            PngOptions options = new PngOptions
            {
                // Maximum lossless compression level (0-9)
                CompressionLevel = 9,
                // Enable progressive loading
                Progressive = true,
                // Use adaptive filter for best results
                FilterType = PngFilterType.Adaptive,
                // Convert to indexed color with an optimal palette (lossless reduction)
                ColorType = PngColorType.IndexedColor,
                // Generate a palette that closely matches the source image
                Palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256, PaletteMiningMethod.Histogram)
            };

            // Save the compressed PNG
            image.Save(outputPath, options);
        }
    }
}