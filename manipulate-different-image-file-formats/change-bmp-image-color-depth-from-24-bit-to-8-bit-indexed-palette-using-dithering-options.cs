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
        string inputPath = @"C:\temp\input24.bmp";
        string outputPath = @"C:\temp\output8.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the 24‑bit BMP image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Dither the image to an 8‑bit indexed palette using Floyd‑Steinberg algorithm
            raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);

            // Configure BMP save options for 8‑bpp with an optimal palette
            BmpOptions saveOptions = new BmpOptions
            {
                BitsPerPixel = 8,
                Palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256),
                Compression = BitmapCompression.Rgb,
                ResolutionSettings = new ResolutionSetting(96.0, 96.0)
            };

            // Save the palettized image
            raster.Save(outputPath, saveOptions);
        }
    }
}