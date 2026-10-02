// HOW-TO: Convert BMP to Indexed PSD with Custom Grayscale Palette in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Aspose.Imaging.Color[] colors = new Aspose.Imaging.Color[256];
                for (int i = 0; i < 256; i++)
                {
                    colors[i] = Aspose.Imaging.Color.FromArgb(i, i, i);
                }

                var palette = new Aspose.Imaging.ColorPalette(colors);

                PsdOptions psdOptions = new PsdOptions();
                psdOptions.ColorMode = ColorModes.Indexed;
                psdOptions.Palette = palette;

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
 * 1. When you need to generate a Photoshop PSD file from a BMP while preserving only 8‑bit indexed colors for compatibility with legacy workflows.
 * 2. When you must create a PSD that uses a custom grayscale palette to ensure consistent tonal mapping across different design tools.
 * 3. When an automated image pipeline requires converting batch BMP assets into indexed PSDs for use in print‑ready templates.
 * 4. When you are building a C# application that needs to export thumbnails as PSDs with limited color depth to reduce file size.
 * 5. When integrating Aspose.Imaging into a content‑management system to transform uploaded BMP images into PSDs with a specific palette for brand guidelines.
 */
