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
            // Output PSD file path
            string outputPath = @"C:\Temp\output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define canvas size
            int width = 500;
            int height = 500;

            // Create PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorMode = ColorModes.Indexed,
                ChannelsCount = (short)1,
                ChannelBitsCount = (short)8,
                CompressionMethod = CompressionMethod.RLE,
                // Simple palette with a few colors
                Palette = new ColorPalette(new Color[]
                {
                    Color.Black,
                    Color.White,
                    Color.Red,
                    Color.Green,
                    Color.Blue
                })
            };

            // Create the PSD canvas
            using (Image image = Image.Create(psdOptions, width, height))
            {
                // Prepare graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define an ellipse shape within a rectangle
                RectangleF ellipseRect = new RectangleF(100f, 100f, 300f, 200f);
                EllipseShape ellipse = new EllipseShape(ellipseRect);

                // Build a figure containing the ellipse
                Figure figure = new Figure();
                figure.AddShape(ellipse);

                // Add the figure to a graphics path
                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);

                // Draw the ellipse outline with a black pen
                Pen pen = new Pen(Color.Black, 3);
                graphics.DrawPath(pen, path);

                // Save the PSD file (source is already bound)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}