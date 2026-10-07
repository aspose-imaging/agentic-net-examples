// HOW-TO: Create Indexed PSD with Custom 256‑Color RGB Palette in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output/custom_palette.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 256;
            int height = 256;

            // Create palette
            Color[] palette = new Color[256];
            for (int i = 0; i < 256; i++)
            {
                int r = (i & 0xE0);
                int g = (i & 0x1C) << 3;
                int b = (i & 0x03) << 6;
                palette[i] = Color.FromArgb(255, r, g, b);
            }

            using (var psdOptions = new PsdOptions())
            {
                psdOptions.Source = new FileCreateSource(outputPath, false);
                psdOptions.ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Indexed;
                psdOptions.Palette = new ColorPalette(palette);

                using (var image = Image.Create(psdOptions, width, height))
                {
                    var raster = (RasterImage)image;
                    int[] pixels = new int[width * height];
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            int index = (x + y * width) % 256;
                            pixels[y * width + x] = palette[index].ToArgb();
                        }
                    }
                    raster.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);
                    image.Save();
                }
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
 * 1. When you need to generate a Photoshop PSD file with an indexed 256‑color palette for use in legacy graphics pipelines or game assets.
 * 2. When you want to programmatically create a palette‑based image to reduce file size while preserving specific RGB tones in a .NET application.
 * 3. When you must export a custom color‑indexed image for printing workflows that require PSD files with defined color tables.
 * 4. When you are building a tool that converts procedural pixel data into a PSD with a deterministic palette for consistent visual testing.
 * 5. When you need to automate the creation of sample PSD files with a known 256‑color lookup table for documentation or UI mock‑ups.
 */
