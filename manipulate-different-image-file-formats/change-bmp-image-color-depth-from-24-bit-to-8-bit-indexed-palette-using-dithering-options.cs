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
            string inputPath = @"c:\temp\input24.bmp";
            string outputPath = @"c:\temp\output8.bmp";

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
                RasterImage rasterImage = (RasterImage)image;

                // Dither to an 8‑bit indexed palette using Floyd‑Steinberg dithering
                rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                // Prepare BMP save options for 8‑bit output
                BmpOptions saveOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    // Generate a palette that best matches the source image
                    Palette = ColorPaletteHelper.GetCloseImagePalette(rasterImage, 256)
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to shrink a 24‑bit BMP file for legacy embedded devices that only accept 8‑bit indexed images, this code dither‑converts and reduces the color depth.
 * 2. When preparing graphics for an old Windows application that requires 8‑bit BMP resources, the code uses Floyd‑Steinberg dithering to retain visual fidelity after conversion.
 * 3. When generating BMP thumbnails for a web service with strict storage limits, the developer can down‑sample the image to 8‑bit indexed palette to meet size constraints while preserving appearance.
 * 4. When creating assets for a retro‑style video game that uses a 256‑color palette, the code converts high‑color BMP artwork into an 8‑bit indexed format with proper dithering.
 * 5. When exporting scanned documents as BMP files for printers that only support 8‑bit indexed images, this code reliably dithers and saves the image in the required format.
 */