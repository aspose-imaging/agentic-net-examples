using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output path (hardcoded)
        string outputPath = @"C:\Temp\output.gif";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create GIF options with a file source bound to the output path
        GifOptions gifOptions = new GifOptions
        {
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new GIF image (200x200) bound to the output file
        using (Image image = Image.Create(gifOptions, 200, 200))
        {
            // Cast to GifImage to access the active frame
            GifImage gif = (GifImage)image;

            // Create a Graphics object for the active frame
            Graphics graphics = new Graphics(gif.ActiveFrame);

            // Instantiate a GraphicsPath
            GraphicsPath graphicsPath = new GraphicsPath();

            // Create a Figure and add shapes to it
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 180f, 180f)));
            figure.AddShape(new EllipseShape(new RectangleF(30f, 30f, 140f, 140f)));

            // Add the Figure to the GraphicsPath
            graphicsPath.AddFigure(figure);

            // Draw the path onto the GIF frame using a blue pen
            graphics.DrawPath(new Pen(Color.Blue, 3), graphicsPath);

            // Save the image (output file is already bound)
            image.Save();
        }
    }
}