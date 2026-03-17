using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output PNG files
        string inputPath = "input.png";
        string outputPath = "output_indexed.png";

        // Load the source image (must contain transparency)
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for palette generation
            RasterImage raster = (RasterImage)image;

            // Generate an optimal 256‑color palette (preserves transparency)
            var palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256, PaletteMiningMethod.Histogram);

            // Create a new PNG image with indexed color type from the raster source
            using (PngImage indexedPng = new PngImage(raster, PngColorType.IndexedColor))
            {
                // Preserve transparency in the indexed PNG
                indexedPng.HasTransparentColor = true;
                indexedPng.TransparentColor = Color.Transparent;

                // Configure PNG save options
                PngOptions saveOptions = new PngOptions
                {
                    CompressionLevel = 9,
                    ColorType = PngColorType.IndexedColor,
                    Palette = palette,
                    Progressive = true
                };

                // Save the indexed PNG while keeping transparency
                indexedPng.Save(outputPath, saveOptions);
            }
        }
    }
}