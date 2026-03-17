using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

string sourcePath = "input.png";          // Path to the source image
string outputPath = "output.psd";         // Desired PSD output path

// Load the source image
using (Image image = Image.Load(sourcePath))
{
    // Cast to RasterImage to work with pixel data
    RasterImage raster = (RasterImage)image;

    // Generate an 8‑bit (256‑color) palette that best matches the source image
    IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);

    // Configure PSD save options
    PsdOptions psdOptions = new PsdOptions
    {
        // Use RLE compression (optional, can be RAW for no compression)
        CompressionMethod = CompressionMethod.RLE,
        // Assign the generated palette for indexed color output
        Palette = palette
        // If the PSD format version you target supports an indexed color mode,
        // you can set it here (uncomment if available):
        // ColorMode = ColorModes.Indexed
    };

    // Save the image as an indexed PSD file
    image.Save(outputPath, psdOptions);
}