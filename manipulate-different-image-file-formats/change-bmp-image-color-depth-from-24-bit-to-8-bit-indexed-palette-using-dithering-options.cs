// HOW-TO: Convert 24‑Bit BMP to 8‑Bit Indexed BMP with Dithering in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\temp\input24.bmp";
            string outputPath = @"C:\temp\output8.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the 24‑bit BMP image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply Floyd‑Steinberg dithering to reduce to an 8‑bit palette
                rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                // Configure BMP save options for 8‑bpp indexed image
                BmpOptions saveOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    Palette = ColorPaletteHelper.GetCloseImagePalette(rasterImage, 256),
                    Compression = BitmapCompression.Rgb,
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0)
                };

                // Save the palettized image
                rasterImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to shrink a high‑color BMP for use on legacy systems that only support 256‑color palettes.
 * 2. When preparing BMP assets for a retro‑style game that requires 8‑bit indexed images with dithering to preserve visual quality.
 * 3. When reducing the file size of large 24‑bit BMP screenshots for faster loading in desktop applications.
 * 4. When converting scanned color BMP documents to an 8‑bit palette to meet printing or archival format constraints.
 * 5. When automating batch processing of BMP files in a C# service to generate web‑friendly, low‑color versions with consistent resolution.
 */
