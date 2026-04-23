using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output.psd";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image bmpImage = Image.Load(inputPath))
            {
                // Create a custom 8‑bit palette (example: red, green, blue, black, white)
                Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[]
                {
                    Aspose.Imaging.Color.Red,
                    Aspose.Imaging.Color.Green,
                    Aspose.Imaging.Color.Blue,
                    Aspose.Imaging.Color.Black,
                    Aspose.Imaging.Color.White
                };
                IColorPalette customPalette = new ColorPalette(paletteColors);

                // Configure PSD save options for 8‑bit indexed mode
                PsdOptions psdOptions = new PsdOptions
                {
                    // Use RLE compression (optional)
                    CompressionMethod = CompressionMethod.RLE,

                    // Set the color mode to Indexed (if supported)
                    ColorMode = ColorModes.Indexed,

                    // Define 8 bits per channel
                    ChannelBitsCount = 8,

                    // One channel for indexed color
                    ChannelsCount = 1,

                    // Assign the custom palette
                    Palette = customPalette
                };

                // Save the image as PSD with the specified options
                bmpImage.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}