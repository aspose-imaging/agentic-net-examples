using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.bmp";
        string outputPath = "Output/sample.psd";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PsdOptions psdOptions = new PsdOptions())
                {
                    // Set indexed color mode with 8‑bit palette
                    psdOptions.ColorMode = ColorModes.Indexed;
                    psdOptions.ChannelBitsCount = (short)8;
                    psdOptions.ChannelsCount = (short)1;
                    psdOptions.CompressionMethod = CompressionMethod.RLE;

                    // Create a custom 256‑color grayscale palette
                    Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[256];
                    for (int i = 0; i < 256; i++)
                    {
                        paletteColors[i] = Aspose.Imaging.Color.FromArgb(255, i, i, i);
                    }
                    psdOptions.Palette = new Aspose.Imaging.ColorPalette(paletteColors);

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