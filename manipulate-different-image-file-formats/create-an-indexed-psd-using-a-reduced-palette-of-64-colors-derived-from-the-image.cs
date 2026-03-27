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
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to work with pixel data
            RasterImage raster = (RasterImage)image;

            // Create a palette with the 64 most frequent colors from the source image
            IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(raster, 64);

            // Configure PSD save options
            PsdOptions psdOptions = new PsdOptions
            {
                // Standard 8 bits per channel
                ChannelBitsCount = 8,
                // RGB channels
                ChannelsCount = 3,
                // Use RGB color mode
                ColorMode = ColorModes.Rgb,
                // No compression (RAW)
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.Raw,
                // Assign the generated palette
                Palette = palette
            };

            // Save the image as an indexed PSD
            image.Save(outputPath, psdOptions);
        }
    }
}