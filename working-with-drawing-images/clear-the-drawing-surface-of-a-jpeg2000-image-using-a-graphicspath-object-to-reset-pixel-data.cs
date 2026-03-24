using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jp2";
        string outputPath = @"C:\temp\output.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load JPEG2000 image
        using (Jpeg2000Image jpegImage = new Jpeg2000Image(inputPath))
        {
            // Create graphics object
            Graphics graphics = new Graphics(jpegImage);

            // Clear the entire surface with white color
            graphics.Clear(Color.White);

            // Create a graphics path covering the whole image
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            RectangleF rect = new RectangleF(jpegImage.Bounds.X, jpegImage.Bounds.Y, jpegImage.Bounds.Width, jpegImage.Bounds.Height);
            figure.AddShape(new RectangleShape(rect));
            path.AddFigure(figure);

            // Fill the path with white color using a solid brush
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                graphics.FillPath(brush, path);
            }

            // Save the modified image
            Jpeg2000Options saveOptions = new Jpeg2000Options();
            jpegImage.Save(outputPath, saveOptions);
        }
    }
}