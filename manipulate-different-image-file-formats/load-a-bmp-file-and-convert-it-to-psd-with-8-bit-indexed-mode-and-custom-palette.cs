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
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.psd";

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
            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PSD save options
                var psdOptions = new PsdOptions
                {
                    // Use RLE compression
                    CompressionMethod = CompressionMethod.RLE,
                    // Set color mode to Indexed (8‑bit palette)
                    ColorMode = ColorModes.Indexed,
                    // 8 bits per channel
                    ChannelBitsCount = 8
                };

                // Define a custom palette (example with five colors)
                Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[]
                {
                    Aspose.Imaging.Color.Red,
                    Aspose.Imaging.Color.Green,
                    Aspose.Imaging.Color.Blue,
                    Aspose.Imaging.Color.Black,
                    Aspose.Imaging.Color.White
                };
                psdOptions.Palette = new ColorPalette(paletteColors);

                // Save as PSD using the defined options
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}