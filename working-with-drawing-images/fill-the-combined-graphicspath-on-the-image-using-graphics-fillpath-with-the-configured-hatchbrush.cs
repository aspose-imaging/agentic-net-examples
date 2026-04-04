using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure PNG options with a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas (500x500)
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Build a combined GraphicsPath
            GraphicsPath combinedPath = new GraphicsPath();

            // First figure: rectangle
            Figure rectFigure = new Figure();
            rectFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            combinedPath.AddFigure(rectFigure);

            // Second figure: ellipse
            Figure ellipseFigure = new Figure();
            ellipseFigure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 150f)));
            combinedPath.AddFigure(ellipseFigure);

            // Configure a HatchBrush
            using (HatchBrush hatchBrush = new HatchBrush())
            {
                hatchBrush.HatchStyle = HatchStyle.Cross;
                hatchBrush.ForegroundColor = Color.Blue;
                hatchBrush.BackgroundColor = Color.Yellow;
                hatchBrush.Opacity = 0.5f; // 50% opacity

                // Fill the combined path with the hatch brush
                graphics.FillPath(hatchBrush, combinedPath);
            }

            // Save the image (output path already bound)
            image.Save();
        }
    }
}