using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"input.bmp";
            string outputPath = @"output_8bpp.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access dithering functionality
                RasterImage rasterImage = (RasterImage)image;

                // Apply Floyd‑Steinberg dithering to reduce to an 8‑bit palette
                rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                // Prepare BMP save options for 8‑bit indexed palette
                BmpOptions saveOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    // Generate a palette that best represents the image colors
                    Palette = ColorPaletteHelper.GetCloseImagePalette(rasterImage, 256),
                    Compression = BitmapCompression.Rgb
                };

                // Save the dithered image as an 8‑bit BMP
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}