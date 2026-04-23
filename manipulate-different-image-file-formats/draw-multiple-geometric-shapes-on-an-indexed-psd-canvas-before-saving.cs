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
            // Hardcoded paths
            string outputPath = @"C:\temp\indexed_output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.ChannelBitsCount = (short)8; // 8 bits per channel
            psdOptions.ChannelsCount = (short)1;    // Indexed uses a single channel
            psdOptions.CompressionMethod = CompressionMethod.RLE;

            // Assign a palette (required for indexed mode)
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.White,
                Color.Black
            });

            // Create the PSD image canvas
            using (Image image = Image.Create(psdOptions, 500, 500))
            {
                // Create graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.Wheat);

                // Draw various shapes
                graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(50, 50, 200, 150));
                graphics.DrawEllipse(new Pen(Color.Blue, 2), new Rectangle(300, 50, 150, 150));
                graphics.DrawLine(new Pen(Color.Red, 2), new Point(50, 300), new Point(450, 300));
                graphics.DrawPolygon(new Pen(Color.Green, 2), new[]
                {
                    new Point(100, 350),
                    new Point(150, 400),
                    new Point(200, 350),
                    new Point(250, 400),
                    new Point(300, 350)
                });
                graphics.DrawArc(new Pen(Color.Purple, 2), new Rectangle(350, 350, 100, 100), 0, 270);
                graphics.DrawPie(new Pen(Color.Orange, 2), new Rectangle(50, 350, 100, 100), 45, 90);
                graphics.DrawBezier(new Pen(Color.Brown, 2),
                    new Point(200, 400), new Point(250, 350), new Point(300, 450), new Point(350, 400));
                graphics.DrawCurve(new Pen(Color.Gray, 2), new[]
                {
                    new Point(400, 350),
                    new Point(420, 380),
                    new Point(440, 360),
                    new Point(460, 390)
                });

                // Save the PSD image (output path already bound)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}