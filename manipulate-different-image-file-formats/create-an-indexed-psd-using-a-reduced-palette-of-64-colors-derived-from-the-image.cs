using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output/output.psd";

        try
        {
            // Verify that the input file exists
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
                // Cast to RasterImage to access pixel data
                RasterImage rasterImage = (RasterImage)image;

                // Create PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Use 8 bits per channel (standard for PSD)
                    ChannelBitsCount = 8,
                    // Set the desired color mode (RGB)
                    ColorMode = ColorModes.Rgb,
                    // Use RLE compression (optional)
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                    // Generate a palette with 64 colors derived from the image
                    Palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette(rasterImage, 64)
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