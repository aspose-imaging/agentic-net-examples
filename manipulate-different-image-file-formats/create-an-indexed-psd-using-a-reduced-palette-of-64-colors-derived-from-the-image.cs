using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access pixel data
                RasterImage raster = (RasterImage)image;

                // Generate a 64‑color palette from the source image
                IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(raster, 64);

                // Configure PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Assign the generated palette
                    Palette = palette,
                    // Use 8 bits per channel (standard for PSD)
                    ChannelBitsCount = 8,
                    // Set color mode; palette will be applied to indexed data
                    ColorMode = ColorModes.Rgb
                };

                // Save the image as an indexed PSD
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}