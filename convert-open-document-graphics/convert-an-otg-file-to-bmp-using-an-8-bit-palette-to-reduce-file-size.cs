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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.otg";
            string outputPath = @"C:\temp\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access pixel data for palette generation
                RasterImage rasterImage = (RasterImage)image;

                // Configure BMP save options for 8‑bit palette
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    // Generate a close 8‑bit palette covering the image colors
                    Palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette(rasterImage, 256),
                    Compression = Aspose.Imaging.FileFormats.Bmp.BitmapCompression.Rgb,
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0)
                };

                // Save the image as BMP using the specified options
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}