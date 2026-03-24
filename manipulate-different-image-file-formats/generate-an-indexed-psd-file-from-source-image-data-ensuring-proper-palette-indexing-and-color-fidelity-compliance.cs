using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Temp\source.png";
        string outputPath = @"C:\Temp\Result\indexed_output.psd";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Cast to RasterImage to be able to generate a palette
            RasterImage raster = sourceImage as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("Source image is not a raster image.");
                return;
            }

            // Build a palette that best represents the source image (256 colors)
            var palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256, PaletteMiningMethod.Histogram);

            // Configure PSD save options for an indexed image
            var psdOptions = new PsdOptions
            {
                // Use 8 bits per channel (standard for indexed palettes)
                ChannelBitsCount = 8,
                // One channel is sufficient when a palette is supplied
                ChannelsCount = 1,
                // Use RGB color mode; the palette will define the actual colors
                ColorMode = ColorModes.Rgb,
                // Apply RLE compression to keep file size reasonable
                CompressionMethod = CompressionMethod.RLE,
                // Default PSD version (6)
                Version = 6,
                // Assign the generated palette
                Palette = palette
            };

            // Save the image as an indexed PSD file
            sourceImage.Save(outputPath, psdOptions);
        }

        Console.WriteLine($"Indexed PSD saved to: {outputPath}");
    }
}