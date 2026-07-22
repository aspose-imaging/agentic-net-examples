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
            string inputPath = @"C:\Images\input24bit.bmp";
            string outputPath = @"C:\Images\output8bit.bmp";

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
                // Cast to RasterImage to access dithering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Floyd‑Steinberg dithering to reduce to 8‑bit palette
                rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                // Prepare BMP save options for 8‑bit indexed image
                BmpOptions saveOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    // Generate a palette that best matches the source image
                    Palette = ColorPaletteHelper.GetCloseImagePalette(rasterImage, 256),
                    // Keep default compression (RGB) and resolution
                };

                // Save the palettized image
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to shrink a 24‑bit BMP file for a legacy Windows application that only accepts 8‑bit indexed images, this code applies Floyd‑Steinberg dithering and creates an optimal palette.
 * 2. When preparing graphics for an embedded device or handheld that requires BMPs limited to 256 colors, the snippet converts the high‑color source to an 8‑bit indexed BMP while preserving visual fidelity.
 * 3. When exporting screenshots from a .NET tool to a game engine that only supports 8‑bit BMP textures, this example automates the palette generation and dithering needed for compatibility.
 * 4. When optimizing BMP assets for web delivery under bandwidth constraints, a developer can use the code to downgrade 24‑bit images to 8‑bit indexed BMPs with Floyd‑Steinberg dithering to retain detail and reduce file size.
 * 5. When archiving scanned documents as BMPs but must stay within a strict storage quota, the code enables conversion from 24‑bit to 8‑bit indexed BMP with a custom palette, ensuring the files remain readable and compact.
 */