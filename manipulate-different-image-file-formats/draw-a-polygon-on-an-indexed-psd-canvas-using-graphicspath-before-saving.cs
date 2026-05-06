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
            // Define output path
            string outputPath = @"C:\Temp\output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.ChannelBitsCount = 8;      // 8 bits per channel
            psdOptions.ChannelsCount = 1;         // Indexed uses a single channel
            // Define a simple palette (red, green, blue, black, white)
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Black,
                Color.White
            });

            // Create a new PSD image with the specified options
            using (Image image = Image.Create(psdOptions, 300, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a GraphicsPath and a Figure
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Define polygon vertices
                PointF[] polygonPoints = new PointF[]
                {
                    new PointF(50f, 50f),
                    new PointF(250f, 50f),
                    new PointF(200f, 200f),
                    new PointF(100f, 200f)
                };

                // Add a PolygonShape to the figure
                figure.AddShape(new PolygonShape(polygonPoints));

                // Add the figure to the path
                path.AddFigure(figure);

                // Draw the polygon using a black pen
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawPath(pen, path);

                // Save the image (output file is already bound via FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}