// HOW-TO: Create Indexed PSD with Concentric Circles Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            int width = 500;
            int height = 500;

            Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[256];
            for (int i = 0; i < 256; i++)
            {
                paletteColors[i] = Aspose.Imaging.Color.FromArgb(i, i, i);
            }
            ColorPalette palette = new ColorPalette(paletteColors);

            PsdOptions options = new PsdOptions();
            options.Source = new FileCreateSource(outputPath, false);
            options.ColorMode = ColorModes.Indexed;
            options.Palette = palette;

            using (var psd = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(psd);
                graphics.Clear(paletteColors[0]);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(paletteColors[255], 3);
                int centerX = width / 2;
                int centerY = height / 2;
                int maxRadius = Math.Min(width, height) / 2 - 10;

                for (int radius = maxRadius; radius > 0; radius -= 20)
                {
                    int left = centerX - radius;
                    int top = centerY - radius;
                    int diameter = radius * 2;
                    Rectangle rect = new Rectangle(left, top, diameter, diameter);
                    graphics.DrawEllipse(pen, rect);
                }

                psd.Save();
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
 * 1. When you need to programmatically generate a PSD file in indexed (grayscale) mode and draw concentric circles as background guides for a printing template.
 * 2. When an automated workflow must create a raster PSD asset with a custom 256‑color palette and visual markers for alignment in a graphics pipeline.
 * 3. When a C# application has to produce a lightweight PSD preview that shows radial patterns without using full RGB color data.
 * 4. When you want to add decorative ring motifs to a PSD canvas for a UI mockup while keeping file size low by using an indexed color mode.
 * 5. When a batch process creates multiple PSD files with evenly spaced circles for testing image‑processing algorithms that require indexed images.
 */
