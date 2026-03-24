using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PNG options (default settings)
        PngOptions pngOptions = new PngOptions();

        // Create a new PNG image with specified dimensions
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize Graphics (do NOT wrap in using)
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Instantiate a GraphicsPath
            GraphicsPath graphicsPath = new GraphicsPath();

            // Create a Figure and add a RectangleShape to it
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));

            // Add the Figure to the GraphicsPath
            graphicsPath.AddFigure(figure);

            // Draw the path onto the image using a Pen
            graphics.DrawPath(new Pen(Color.Blue, 3), graphicsPath);

            // Save the image to the output file
            image.Save(outputPath, pngOptions);
        }
    }
}