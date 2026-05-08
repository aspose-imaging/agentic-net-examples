using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\temp\output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.Wheat);

                // Build a combined GraphicsPath
                Aspose.Imaging.GraphicsPath combinedPath = new Aspose.Imaging.GraphicsPath();

                // First figure with a rectangle and an ellipse
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(100f, 100f, 200f, 200f)));

                // Add the figure to the path
                combinedPath.AddFigure(figure);

                // Configure a HatchBrush
                using (HatchBrush hatchBrush = new HatchBrush())
                {
                    hatchBrush.BackgroundColor = Aspose.Imaging.Color.LightGray;
                    hatchBrush.ForegroundColor = Aspose.Imaging.Color.Blue;

                    // Fill the interior of the combined path
                    graphics.FillPath(hatchBrush, combinedPath);
                }

                // Save the image (the output file is already bound to the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}