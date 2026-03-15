// Create an indexed PSD image from an existing raster image and save it with a palette.
// The code loads a source image, generates a 256‑color palette that best fits the image,
// configures PSD save options for an indexed (8‑bit) color mode, and saves the result as a PSD file.

string sourcePath = @"C:\Images\source.png";   // Path to the source image (any supported format)
string destinationPath = @"C:\Images\indexed_output.psd"; // Path where the PSD will be saved

// Load the source image using Aspose.Imaging's load rule.
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(sourcePath))
{
    // Cast to RasterImage to work with pixel data and palette generation.
    Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

    // Generate a palette with up to 256 entries that best represents the source image.
    // This uses the built‑in ColorPaletteHelper (no custom palette logic required).
    Aspose.Imaging.IColorPalette palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette(raster, 256);

    // Prepare PSD save options.
    Aspose.Imaging.ImageOptions.PsdOptions psdOptions = new Aspose.Imaging.ImageOptions.PsdOptions();

    // Assign the generated palette to the options.
    psdOptions.Palette = palette;

    // Configure the PSD to use an 8‑bit indexed color channel.
    // For indexed PSDs we set a single channel (the palette index) with 8 bits per entry.
    psdOptions.ChannelsCount = 1;          // One channel holds the palette index.
    psdOptions.ChannelBitsCount = 8;       // 8 bits per pixel → 256 colors.

    // Set the color mode to Bitmap (1‑bit) or Grayscale as needed.
    // Using Bitmap here forces a palette‑based image when a palette is supplied.
    psdOptions.ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Bitmap;

    // Save the image as a PSD file using the configured options (save rule).
    image.Save(destinationPath, psdOptions);
}