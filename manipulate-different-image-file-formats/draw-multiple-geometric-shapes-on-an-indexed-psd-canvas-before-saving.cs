using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

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

            // Configure PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            // Simple palette with a few colors
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.White,
                Color.Black
            });

            // Create the PSD canvas (800x600)
            using (Image image = Image.Create(psdOptions, 800, 600))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen for outlines
                Pen blackPen = new Pen(Color.Black, 2);

                // Rectangle outline
                graphics.DrawRectangle(blackPen, new Rectangle(50, 50, 300, 200));

                // Filled rectangle
                using (SolidBrush redBrush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(redBrush, new Rectangle(400, 50, 200, 150));
                }

                // Ellipse outline
                graphics.DrawEllipse(blackPen, new Rectangle(50, 300, 200, 150));

                // Filled ellipse
                using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
                {
                    graphics.FillEllipse(blueBrush, new Rectangle(300, 300, 250, 150));
                }

                // Line
                graphics.DrawLine(blackPen, new Point(600, 400), new Point(750, 550));

                // Polygon outline
                Point[] polygonPoints = new Point[]
                {
                    new Point(100, 500),
                    new Point(150, 450),
                    new Point(200, 500),
                    new Point(175, 550),
                    new Point(125, 550)
                };
                graphics.DrawPolygon(blackPen, polygonPoints);

                // Filled polygon
                using (SolidBrush greenBrush = new SolidBrush(Color.Green))
                {
                    graphics.FillPolygon(greenBrush, polygonPoints);
                }

                // Save the PSD (output is already bound to the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}