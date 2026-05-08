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
            // Output file path (hard‑coded)
            string outputPath = "output.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a simple palette for the indexed image
            Color[] paletteColors = new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue
            };
            var palette = new ColorPalette(paletteColors);

            // Configure PSD options for an indexed canvas
            PsdOptions psdOptions = new PsdOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorMode = ColorModes.Indexed,
                Palette = palette,
                CompressionMethod = CompressionMethod.RLE,
                ChannelBitsCount = 8,   // 8 bits per channel
                ChannelsCount = 1       // Indexed images use a single channel
            };

            // Create a 500x500 indexed PSD image
            using (Image image = Image.Create(psdOptions, 500, 500))
            {
                // Prepare graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a graphics path containing an ellipse shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 300, 200)));
                path.AddFigure(figure);

                // Draw the ellipse with a black pen
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawPath(pen, path);

                // Since the image was created with a FileCreateSource, just save the canvas
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}