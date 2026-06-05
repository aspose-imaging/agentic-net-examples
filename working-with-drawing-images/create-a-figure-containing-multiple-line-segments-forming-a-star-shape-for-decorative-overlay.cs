using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"c:\temp\star.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Prepare a graphics path and a figure
                Aspose.Imaging.GraphicsPath graphicsPath = new Aspose.Imaging.GraphicsPath();
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

                // Define points of a star shape
                Aspose.Imaging.PointF[] starPoints = new Aspose.Imaging.PointF[]
                {
                    new Aspose.Imaging.PointF(250f, 50f),
                    new Aspose.Imaging.PointF(280f, 180f),
                    new Aspose.Imaging.PointF(400f, 180f),
                    new Aspose.Imaging.PointF(300f, 250f),
                    new Aspose.Imaging.PointF(340f, 380f),
                    new Aspose.Imaging.PointF(250f, 300f),
                    new Aspose.Imaging.PointF(160f, 380f),
                    new Aspose.Imaging.PointF(200f, 250f),
                    new Aspose.Imaging.PointF(100f, 180f),
                    new Aspose.Imaging.PointF(220f, 180f)
                };

                // Add a closed polygon shape (the star) to the figure
                figure.AddShape(new PolygonShape(starPoints, true));

                // Add the figure to the graphics path
                graphicsPath.AddFigure(figure);

                // Draw the path with a black pen
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), graphicsPath);

                // Save the image
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a 500×500 PNG badge with a decorative star overlay for user profile pictures in a web application.
 * 2. When an e‑commerce platform wants to programmatically add a star watermark to product thumbnail images to highlight featured items.
 * 3. When a reporting tool must create a printable PNG star‑shaped diagram for inclusion in PDF reports or dashboards.
 * 4. When a game developer wants to produce dynamic star icons at runtime without storing pre‑made image files.
 * 5. When an automated email system needs to attach a custom star‑shaped PNG banner to promotional newsletters generated on the fly.
 */