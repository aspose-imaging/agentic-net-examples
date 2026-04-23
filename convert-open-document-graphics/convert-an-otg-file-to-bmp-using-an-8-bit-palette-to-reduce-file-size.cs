using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.otg";
        string outputPath = @"C:\Images\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image otgImage = Image.Load(inputPath))
        {
            // Prepare BMP save options with 8‑bit palette
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 8,
                Compression = Aspose.Imaging.FileFormats.Bmp.BitmapCompression.Rgb
            };

            // If the loaded image is a raster image, generate a close 8‑bit palette
            if (otgImage is RasterImage raster)
            {
                bmpOptions.Palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);
            }
            else
            {
                // Fallback to a standard 8‑bit grayscale palette
                bmpOptions.Palette = ColorPaletteHelper.Create8BitGrayscale(false);
            }

            // Save the image as BMP using the specified options
            otgImage.Save(outputPath, bmpOptions);
        }
    }
}