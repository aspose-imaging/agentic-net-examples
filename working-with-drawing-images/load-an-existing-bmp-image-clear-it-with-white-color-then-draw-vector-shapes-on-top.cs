using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a Graphics instance for drawing
            Graphics graphics = new Graphics(image);

            // Clear the image with white color
            graphics.Clear(Color.White);

            // Draw vector shapes
            // Draw a black line
            graphics.DrawLine(new Pen(Color.Black, 2), new Point(20, 20), new Point(200, 20));

            // Draw a red rectangle
            graphics.DrawRectangle(new Pen(Color.Red, 3), new Rectangle(30, 40, 150, 100));

            // Draw a blue ellipse
            graphics.DrawEllipse(new Pen(Color.Blue, 2), new Rectangle(50, 160, 120, 80));

            // Draw a green polygon
            graphics.DrawPolygon(new Pen(Color.Green, 2), new[]
            {
                new Point(100, 260),
                new Point(150, 300),
                new Point(80, 340),
                new Point(40, 300)
            });

            // Prepare BMP save options with a bound file source
            BmpOptions bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the modified image
            image.Save(outputPath, bmpOptions);
        }
    }
}