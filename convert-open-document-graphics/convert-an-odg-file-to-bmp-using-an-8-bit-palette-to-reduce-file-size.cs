using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.odg";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure BMP save options for 8‑bit palette
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 8
                };

                // Attempt to create a palette based on the source image
                if (image is RasterImage raster)
                {
                    bmpOptions.Palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);
                }
                else
                {
                    // Fallback to a standard 8‑bit grayscale palette
                    bmpOptions.Palette = ColorPaletteHelper.Create8BitGrayscale(false);
                }

                // Save the image as BMP using the configured options
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}