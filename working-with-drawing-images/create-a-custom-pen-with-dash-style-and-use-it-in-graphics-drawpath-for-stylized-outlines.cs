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
        // Hardcoded output path
        string outputPath = @"C:\temp\custompen_output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file source bound to the output path
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas
        using (Image image = Image.Create(pngOptions, 400, 400))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.LightGray);

            // Build a graphics path containing a rectangle shape
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 300f)));
            path.AddFigure(figure);

            // Create a custom pen with dash style
            Pen pen = new Pen(Color.Blue, 5f);
            pen.DashStyle = DashStyle.Dash;

            // Draw the path using the custom pen
            graphics.DrawPath(pen, path);

            // Save the image (output is already bound to the file source)
            image.Save();
        }
    }
}