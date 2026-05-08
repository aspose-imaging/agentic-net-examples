using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.dng";
            string outputPath = @"C:\Images\sample_converted.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to work with palette and dithering
                RasterImage rasterImage = (RasterImage)image;

                // Generate a 256‑color palette from the image
                IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(rasterImage, 256);

                // Apply dithering using the generated palette (8‑bit = 256 colors)
                rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, palette);

                // Prepare GIF save options with the custom palette
                GifOptions gifOptions = new GifOptions
                {
                    Palette = palette,
                    // Optional: enable palette correction for better results
                    DoPaletteCorrection = true
                };

                // Save the image as GIF using the specified options
                rasterImage.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}