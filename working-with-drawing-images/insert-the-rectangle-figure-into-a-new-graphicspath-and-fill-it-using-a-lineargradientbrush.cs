// HOW-TO: Create PNG With Gradient Filled Rectangle Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = @"output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a graphics path and a figure
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Add a rectangle shape to the figure
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 300f)));

                // Add the figure to the path
                path.AddFigure(figure);

                // Create a linear gradient brush
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new PointF(0f, 0f),
                    new PointF(500f, 0f),
                    Color.Blue,
                    Color.Red))
                {
                    // Fill the path with the gradient brush
                    graphics.FillPath(brush, path);
                }

                // Optionally draw the outline
                graphics.DrawPath(new Pen(Color.Black, 2), path);

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
 * 1. When you need to generate a PNG banner with a blue‑to‑red gradient rectangle for a website header using Aspose.Imaging in C#.
 * 2. When you want to programmatically create a gradient‑filled button background in a Windows Forms or WPF application.
 * 3. When you must produce a printable flyer image that contains a smooth linear gradient rectangle for marketing material.
 * 4. When you are building a chart or infographic and require a gradient‑shaded rectangle as a legend or highlight area.
 * 5. When you automate thumbnail creation that adds a gradient rectangle overlay to indicate status or category.
 */
