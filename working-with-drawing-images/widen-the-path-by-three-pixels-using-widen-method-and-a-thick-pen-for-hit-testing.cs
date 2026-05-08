using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = "output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set PNG options and bind the output stream
            PngOptions pngOptions = new PngOptions();
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                pngOptions.Source = new StreamSource(stream);

                // Create a blank image
                using (Image image = Image.Create(pngOptions, 400, 300))
                {
                    // Obtain a graphics object for drawing
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    // Build a simple path (a rectangle)
                    GraphicsPath path = new GraphicsPath();
                    Figure figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                    path.AddFigure(figure);

                    // Draw the original path with a thin blue pen
                    Pen thinPen = new Pen(Color.Blue, 1);
                    graphics.DrawPath(thinPen, path);

                    // Widen the path by 3 pixels using a thick red pen (for hit‑testing)
                    Pen thickPen = new Pen(Color.Red, 3);
                    path.Widen(thickPen);

                    // Draw the widened path with a green pen to visualize the result
                    Pen widenedPen = new Pen(Color.Green, 1);
                    graphics.DrawPath(widenedPen, path);

                    // Save the image (the stream is already bound)
                    image.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}