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
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"C:\Images\output_64color.psd";

        try
        {
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
                // Cast to RasterImage to access pixel data
                RasterImage rasterImage = (RasterImage)image;

                // Create PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Use 8 bits per channel (standard for PSD)
                    ChannelBitsCount = 8,
                    // Set color mode to RGB (indexed PSD will use the palette)
                    ColorMode = ColorModes.Rgb,
                    // Assign a reduced palette of 64 colors derived from the image
                    Palette = ColorPaletteHelper.GetCloseImagePalette(rasterImage, 64)
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