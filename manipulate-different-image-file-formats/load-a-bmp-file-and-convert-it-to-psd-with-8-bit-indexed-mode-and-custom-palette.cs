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
            // Hardcoded input and output paths
            string baseDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(baseDir, "Input", "sample.bmp");
            string outputPath = Path.Combine(baseDir, "Output", "sample.psd");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare custom 8‑bit palette (simple grayscale palette)
                Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[256];
                for (int i = 0; i < 256; i++)
                {
                    byte v = (byte)i;
                    paletteColors[i] = Aspose.Imaging.Color.FromArgb(v, v, v);
                }
                var customPalette = new Aspose.Imaging.ColorPalette(paletteColors);

                // Configure PSD options for 8‑bit indexed mode
                var psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Indexed,
                    ChannelBitsCount = (short)8,
                    ChannelsCount = (short)1,
                    Palette = customPalette
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
 * 1. When a developer needs to import legacy BMP assets into a Photoshop workflow and preserve memory‑efficient 8‑bit indexed colors with a custom grayscale palette.
 * 2. When a C# application must generate PSD files for a design pipeline that requires RLE compression and explicit channel settings for compatibility with older Photoshop versions.
 * 3. When an automated image‑processing service has to batch‑convert scanned BMP documents into indexed‑color PSDs to reduce file size while maintaining exact palette control.
 * 4. When a game‑development toolchain needs to transform BMP textures into PSD layers with a predefined 256‑color palette for use in sprite editors that only support indexed modes.
 * 5. When a digital‑archiving solution must store BMP graphics as PSD files with 8‑bit indexed mode to ensure consistent color reproduction across platforms that read Photoshop files.
 */