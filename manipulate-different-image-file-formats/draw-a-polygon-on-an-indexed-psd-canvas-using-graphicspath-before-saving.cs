using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Define output path
        string outputPath = @"C:\Temp\output.psd";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure PSD options for indexed color mode
        PsdOptions psdOptions = new PsdOptions();
        psdOptions.Source = new FileCreateSource(outputPath, false);
        psdOptions.ColorMode = ColorModes.Indexed;
        psdOptions.CompressionMethod = CompressionMethod.RLE;
        psdOptions.ChannelsCount = (short)1;          // Indexed uses a single channel
        psdOptions.ChannelBitsCount = (short)8;      // 8 bits per palette entry
        psdOptions.Version = 6;                      // PSD version

        // Create a simple grayscale palette (256 colors)
        Color[] paletteColors = new Color[256];
        for (int i = 0; i < 256; i++)
        {
            paletteColors[i] = Color.FromArgb(255, i, i, i);
        }
        psdOptions.Palette = new ColorPalette(paletteColors);

        // Create a blank PSD image (500x500)
        using (Image image = Image.Create(psdOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a GraphicsPath and a Figure
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Define polygon points
            PointF[] polygonPoints = new PointF[]
            {
                new PointF(100f, 100f),
                new PointF(400f, 100f),
                new PointF(250f, 400f)
            };

            // Add a PolygonShape to the figure
            figure.AddShape(new PolygonShape(polygonPoints));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the polygon with a blue pen
            Pen pen = new Pen(Color.Blue, 2);
            graphics.DrawPath(pen, path);

            // Save the PSD image (output is already bound to the file)
            image.Save();
        }
    }
}