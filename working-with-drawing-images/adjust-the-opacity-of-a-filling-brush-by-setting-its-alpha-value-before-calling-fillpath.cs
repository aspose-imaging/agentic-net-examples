using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = @"output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a PNG image with a bound stream
            using (FileStream outStream = new FileStream(outputPath, FileMode.Create))
            {
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(outStream);

                using (Image image = Image.Create(pngOptions, 400, 400))
                {
                    // Initialize graphics
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    // Build a simple rectangular path
                    GraphicsPath path = new GraphicsPath();
                    Figure figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 300f)));
                    path.AddFigure(figure);

                    // Create a brush with 50% opacity
                    using (SolidBrush brush = new SolidBrush())
                    {
                        brush.Color = Color.Blue;
                        brush.Opacity = 0.5f; // Opacity between 0 (transparent) and 1 (opaque)

                        // Fill the path using the brush
                        graphics.FillPath(brush, path);
                    }

                    // Save the image (stream is already bound)
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