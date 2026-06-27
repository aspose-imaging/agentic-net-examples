using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\Temp\ConcentricCircles.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define canvas size
            int width = 800;
            int height = 800;

            // Create a simple grayscale palette (256 shades)
            Color[] paletteColors = new Color[256];
            for (int i = 0; i < 256; i++)
            {
                paletteColors[i] = Color.FromArgb(i, i, i);
            }
            ColorPalette palette = new ColorPalette(paletteColors);

            // Configure PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.ChannelsCount = (short)1;          // One channel for palette index
            psdOptions.ChannelBitsCount = (short)8;      // 8 bits per channel
            psdOptions.Version = 6;
            psdOptions.Palette = palette;

            // Create the PSD image canvas
            using (Image image = Image.Create(psdOptions, width, height))
            {
                // Create graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Center point
                int centerX = width / 2;
                int centerY = height / 2;

                // Draw concentric circles
                int maxRadius = Math.Min(width, height) / 2 - 10;
                int step = 20;
                for (int radius = maxRadius; radius > 0; radius -= step)
                {
                    int left = centerX - radius;
                    int top = centerY - radius;
                    int diameter = radius * 2;
                    Rectangle rect = new Rectangle(left, top, diameter, diameter);
                    Pen pen = new Pen(Color.Black, 2);
                    graphics.DrawEllipse(pen, rect);
                }

                // Save the image (output path already bound)
                image.Save();
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
 * 1. When a developer needs to generate a lightweight PSD file with a 256‑color indexed palette for a background pattern in a Photoshop mock‑up, this code can draw concentric circles on the canvas and save it.
 * 2. When testing PSD import/export pipelines or verifying that RLE compression and indexed color handling work correctly, a reproducible test image of concentric circles can be created with this snippet.
 * 3. When producing printable spot‑color guides or calibration charts that must stay within a single 8‑bit channel, the code provides a quick way to generate the required PSD artwork.
 * 4. When building a web service that returns a PSD thumbnail containing simple geometric shapes for preview purposes, developers can use this routine to draw concentric circles on an indexed image before sending it to the client.
 * 5. When creating assets for a game UI where the final artwork will be edited in Photoshop and must retain a small palette for performance, this example shows how to programmatically generate the initial PSD with concentric circles.
 */