using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to work with palettes
                RasterImage raster = (RasterImage)image;

                // Create a 256‑color palette from the source image
                IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);

                // Configure PSD save options and assign the palette
                PsdOptions psdOptions = new PsdOptions
                {
                    Palette = palette,
                    // Use indexed (bitmap) color mode for palettized PSD
                    ColorMode = ColorModes.Bitmap
                };

                // Save the image as an indexed PSD
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}