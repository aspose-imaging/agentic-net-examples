using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class PreserveAlphaWhenIndexingPng
{
    static void Main()
    {
        // Path to the source PNG image (may contain alpha channel)
        string sourceFilePath = @"C:\Images\source.png";

        // Path where the processed PNG will be saved
        string outputFilePath = @"C:\Images\output.png";

        // Load the PNG image
        using (Image image = Image.Load(sourceFilePath))
        {
            // Cast to PngImage to access PNG‑specific properties
            PngImage pngImage = (PngImage)image;

            // Determine whether the source image has an alpha channel
            bool hasAlpha = pngImage.HasAlpha;

            // Prepare PNG save options
            PngOptions saveOptions = new PngOptions();

            if (hasAlpha)
            {
                // Preserve the existing alpha channel by using TruecolorWithAlpha
                saveOptions.ColorType = PngColorType.TruecolorWithAlpha;
            }
            else
            {
                // No alpha channel – we can safely use indexed color
                saveOptions.ColorType = PngColorType.IndexedColor;

                // Generate an optimal palette (up to 256 colors) for the image
                saveOptions.Palette = ColorPaletteHelper.GetCloseImagePalette(
                    (RasterImage)pngImage, 256, PaletteMiningMethod.Histogram);

                // If the image uses a transparent color (tRNS), preserve it
                if (pngImage.HasTransparentColor)
                {
                    // Set the transparent color on the image before saving
                    // This ensures the tRNS chunk is written to the indexed PNG
                    pngImage.HasTransparentColor = true;
                }
            }

            // Save the image with the configured options.
            // The alpha channel (if present) is retained, and indexed images keep their transparency.
            image.Save(outputFilePath, saveOptions);
        }

        Console.WriteLine("Image saved with transparency preserved.");
    }
}