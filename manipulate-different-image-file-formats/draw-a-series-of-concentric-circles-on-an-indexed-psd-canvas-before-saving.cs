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
            // Output PSD file path
            string outputPath = @"C:\temp\concentric_circles.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a simple palette for indexed color mode
            Color[] paletteColors = new Color[] { Color.Black, Color.White };
            ColorPalette palette = new ColorPalette(paletteColors);

            // Configure PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.Palette = palette;
            psdOptions.CompressionMethod = CompressionMethod.RLE; // optional compression

            int width = 500;
            int height = 500;

            // Create the PSD image canvas
            using (Image image = Image.Create(psdOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Parameters for concentric circles
                int centerX = width / 2;
                int centerY = height / 2;
                int maxRadius = Math.Min(width, height) / 2 - 10;
                int step = 20;

                // Draw circles from outermost to innermost
                for (int radius = maxRadius; radius > 0; radius -= step)
                {
                    int left = centerX - radius;
                    int top = centerY - radius;
                    int diameter = radius * 2;
                    graphics.DrawEllipse(new Pen(Color.Black, 1), new Rectangle(left, top, diameter, diameter));
                }

                // Save the image (output is already bound to the file)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}