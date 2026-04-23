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
            // Output PSD file path (hard‑coded)
            string outputPath = @"C:\temp\output.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a simple palette for the indexed image
            Color[] paletteColors = new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow,
                Color.Cyan,
                Color.Magenta
            };
            ColorPalette palette = new ColorPalette(paletteColors);

            // Configure PSD options for an indexed canvas
            PsdOptions psdOptions = new PsdOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorMode = ColorModes.Indexed,
                CompressionMethod = CompressionMethod.RLE,
                ChannelBitsCount = (short)8,
                ChannelsCount = (short)1,
                Palette = palette,
                Version = 6
            };

            // Create a 500x500 indexed PSD image
            using (Image image = Image.Create(psdOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(paletteColors[0]);

                // Define polygon vertices
                PointF[] polygonPoints = new PointF[]
                {
                    new PointF(100f, 100f),
                    new PointF(400f, 100f),
                    new PointF(250f, 400f)
                };

                // Create a figure and add a closed polygon shape
                Figure figure = new Figure();
                figure.AddShape(new PolygonShape(polygonPoints, true));

                // Build a graphics path containing the figure
                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);

                // Draw the polygon outline
                Pen pen = new Pen(Color.White, 2);
                graphics.DrawPath(pen, path);

                // Save the image (output file is already bound to the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}