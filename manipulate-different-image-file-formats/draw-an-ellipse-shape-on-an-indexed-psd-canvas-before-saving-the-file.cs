// HOW-TO: Draw Ellipse on Indexed PSD Canvas and Save with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\Temp\output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define canvas size
            int width = 500;
            int height = 500;

            // Create a simple palette for indexed color mode
            Color[] paletteColors = new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue
            };
            var palette = new ColorPalette(paletteColors);

            // Configure PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorMode = ColorModes.Indexed,
                Palette = palette,
                ChannelBitsCount = 8,   // 8 bits per channel
                ChannelsCount = 1,      // Indexed images have a single channel
                CompressionMethod = CompressionMethod.RLE,
                Version = 6
            };

            // Create the PSD image canvas
            using (Image image = Image.Create(psdOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a graphics path with an ellipse shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                // Ellipse bounded by a rectangle (x, y, width, height)
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 300f, 200f)));
                path.AddFigure(figure);

                // Draw the ellipse using a black pen
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawPath(pen, path);

                // Save the PSD file (output path already bound via FileCreateSource)
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
 * 1. When you need to generate a PSD file with a limited color palette and add a vector ellipse as a thumbnail or placeholder.
 * 2. When creating game UI assets that require indexed color mode and a simple ellipse overlay.
 * 3. When automating batch processing of PSD templates that must include an ellipse watermark without using Photoshop.
 * 4. When exporting diagram elements to a PSD file while preserving a small palette for web‑optimized graphics.
 * 5. When programmatically producing printable mock‑ups where an ellipse represents a logo or focus area in an indexed PSD.
 */
