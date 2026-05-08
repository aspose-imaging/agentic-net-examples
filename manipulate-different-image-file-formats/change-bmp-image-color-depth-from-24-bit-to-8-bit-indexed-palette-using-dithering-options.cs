using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input24.bmp";
        string outputPath = @"C:\temp\output8.bmp";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the 24‑bit BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access Dither method
                RasterImage rasterImage = (RasterImage)image;

                // Apply Floyd‑Steinberg dithering to reduce to 8‑bit palette
                rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                // Prepare BMP save options for 8‑bit indexed image
                BmpOptions saveOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    // Generate a palette that best matches the image colors
                    Palette = ColorPaletteHelper.GetCloseImagePalette(rasterImage, 256),
                    Compression = BitmapCompression.Rgb,
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0)
                };

                // Save the dithered image as an 8‑bit BMP
                rasterImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}