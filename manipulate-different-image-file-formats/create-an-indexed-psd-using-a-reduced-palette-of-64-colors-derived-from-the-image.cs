using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.png";
            string outputPath = "Output/result.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Input image is not a raster image.");
                    return;
                }

                var palette = ColorPaletteHelper.GetCloseImagePalette(raster, 64, PaletteMiningMethod.Histogram);

                using (PsdOptions psdOptions = new PsdOptions())
                {
                    psdOptions.ColorMode = ColorModes.Indexed;
                    psdOptions.CompressionMethod = CompressionMethod.RLE;
                    psdOptions.ChannelBitsCount = 8;
                    psdOptions.ChannelsCount = 1;
                    psdOptions.Palette = palette;

                    image.Save(outputPath, psdOptions);
                }
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
 * 1. When a developer needs to convert a high‑resolution PNG into a Photoshop PSD with an indexed 64‑color palette for faster web preview or legacy software compatibility.
 * 2. When building an automated asset pipeline that reduces file size by saving images as indexed PSDs with RLE compression for game textures.
 * 3. When creating print‑ready PSD files from raster images while preserving limited color information to meet spot‑color printing requirements.
 * 4. When generating PSD mock‑ups from user‑uploaded images and need to enforce a consistent 64‑color palette to maintain brand color guidelines.
 * 5. When developing a batch conversion tool that processes multiple PNGs and outputs indexed PSDs to support older Photoshop versions that only handle indexed color modes.
 */