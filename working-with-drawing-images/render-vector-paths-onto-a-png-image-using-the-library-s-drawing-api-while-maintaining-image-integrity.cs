using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

public class Program
{
    static void Main(string[] args)
    {
        // Output PNG file path (hardcoded)
        string outputPath = "output/output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream bound to the output file
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure PNG options with the stream source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            int width = 500;
            int height = 500;

            // Create a new PNG image with the specified dimensions
            using (Image image = Image.Create(pngOptions, width, height))
            {
                // Initialize Graphics for drawing on the image
                Graphics graphics = new Graphics(image);

                // Build a graphics path consisting of multiple vector shapes
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Add a rectangle shape to the figure
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

                // Add an ellipse shape to the figure
                figure.AddShape(new EllipseShape(new RectangleF(300f, 100f, 150f, 150f)));

                // Add a pie shape to the figure
                figure.AddShape(new PieShape(new RectangleF(100f, 300f, 200f, 200f), 0f, 120f));

                // Attach the figure to the graphics path
                path.AddFigure(figure);

                // Define a pen for stroking the path
                Pen pen = new Pen(Color.Blue, 3);

                // Draw the constructed path onto the image
                graphics.DrawPath(pen, path);

                // Save the image (output is already bound to the stream)
                image.Save();
            }
        }
    }
}