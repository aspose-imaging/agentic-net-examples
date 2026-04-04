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
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\source.png";
        string outputPath = @"c:\temp\output.png";

        // Validate that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // First load the source image to obtain its dimensions
        int width, height;
        using (RasterImage temp = (RasterImage)Image.Load(inputPath))
        {
            width = temp.Width;
            height = temp.Height;
        }

        // Create PNG options for the output image
        PngOptions pngOptions = new PngOptions();

        // Create a new canvas image with the same size as the source
        using (Image canvas = Image.Create(pngOptions, width, height))
        {
            // Draw the source image onto the canvas
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);
                graphics.DrawImage(sourceImage, new Point(0, 0));
            } // sourceImage is disposed here; GraphicsPath should not retain any reference to it

            // Create a GraphicsPath and draw it onto the same canvas
            Graphics graphicsPath = new Graphics(canvas);
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Add a rectangle shape to the figure
            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, width - 20f, height - 20f)));
            path.AddFigure(figure);

            // Render the path
            graphicsPath.DrawPath(new Pen(Color.Blue, 3), path);

            // Save the final image to the output path
            canvas.Save(outputPath, pngOptions);
        }
    }
}