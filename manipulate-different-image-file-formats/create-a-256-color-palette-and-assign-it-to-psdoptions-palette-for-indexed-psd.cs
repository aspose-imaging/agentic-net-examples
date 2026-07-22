using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Obtain a 256‑color palette from the source image
                var raster = (RasterImage)image;
                var palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);

                // Configure PSD save options for indexed (bitmap) mode
                var psdOptions = new PsdOptions
                {
                    ColorMode = ColorModes.Bitmap, // indexed color mode
                    Palette = palette
                };

                // Save as PSD with the specified options
                image.Save(outputPath, psdOptions);
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
 * 1. When a developer needs to convert a high‑color PNG into an indexed‑color Photoshop PSD file with a 256‑color palette for compatibility with older design tools.
 * 2. When a web‑to‑print workflow requires reducing image size by saving PNG assets as PSDs using bitmap color mode and a custom palette generated from the source image.
 * 3. When an automated batch process must generate PSD files that use a limited palette to meet file‑size constraints for mobile app assets.
 * 4. When a digital asset management system needs to store thumbnails as indexed PSDs to preserve color fidelity while keeping storage overhead low.
 * 5. When a legacy Photoshop plugin only supports indexed PSD files, and a C# application must create those files by extracting a 256‑color palette from existing raster images.
 */