using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class IndexedPsdGenerator
{
    static void Main()
    {
        // Path to the source image (any raster format supported by Aspose.Imaging)
        string sourcePath = @"C:\Images\source.png";

        // Path where the indexed PSD will be saved
        string outputPath = @"C:\Images\output_indexed.psd";

        // Load the source image
        using (Image image = Image.Load(sourcePath))
        {
            // Cast to RasterImage to access pixel data
            RasterImage raster = (RasterImage)image;

            // Generate an 8‑bit palette (max 256 colors) that best represents the source image
            IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);

            // Configure PSD saving options
            PsdOptions psdOptions = new PsdOptions
            {
                // Assign the generated palette – this forces the PSD to be saved as an indexed image
                Palette = palette,

                // Set bits per channel to 8 (standard for 256‑color palettes)
                ChannelBitsCount = 8,

                // Optional: define resolution (96 DPI is common)
                ResolutionSettings = new ResolutionSetting(96.0, 96.0)
            };

            // If the library version supports explicit indexed color mode, set it.
            // Commented out because some versions expose only Bitmap, Grayscale, RGB.
            // psdOptions.ColorMode = ColorModes.Indexed;

            // Save the image as an indexed PSD using the configured options
            image.Save(outputPath, psdOptions);
        }
    }
}