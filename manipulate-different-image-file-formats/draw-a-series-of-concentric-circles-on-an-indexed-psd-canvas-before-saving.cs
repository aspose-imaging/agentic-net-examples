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
            // Output path (hardcoded)
            string outputPath = "output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define PSD creation options for an indexed image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.Version = 6;
            psdOptions.ChannelBitsCount = 8; // short implicitly
            psdOptions.ChannelsCount = 1;   // indexed palette uses 1 channel

            // Define a simple palette (black, white, red, green, blue)
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue
            });

            // Canvas size
            int width = 500;
            int height = 500;

            // Create the PSD image canvas
            using (Image image = Image.Create(psdOptions, width, height))
            {
                // Create graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Center of the canvas
                int centerX = width / 2;
                int centerY = height / 2;

                // Maximum radius and step between circles
                int maxRadius = Math.Min(width, height) / 2 - 10;
                int step = 20;

                // Draw concentric circles
                for (int radius = maxRadius; radius > 0; radius -= step)
                {
                    Rectangle bounds = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);
                    Color circleColor = ((radius / step) % 2 == 0) ? Color.Black : Color.Gray;
                    Pen pen = new Pen(circleColor, 2);
                    graphics.DrawEllipse(pen, bounds);
                }

                // Save the PSD image (output path already bound via FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}