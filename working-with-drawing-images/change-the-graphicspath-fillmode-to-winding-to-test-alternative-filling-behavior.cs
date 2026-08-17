// HOW-TO: How To Fill Overlapping Shapes Using Winding Mode In C# (Aspose.Imaging for .NET)
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
        string outputPath = @"C:\temp\output_winding.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Create PNG options with a stream source bound to the output file
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                // Create a 400x400 image
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 400, 400))
                {
                    // Initialize graphics for the image
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.LightGray);

                    // Create a GraphicsPath with FillMode.Winding
                    Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath(Aspose.Imaging.FillMode.Winding);

                    // Build a figure with overlapping shapes
                    Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                    figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 200f, 200f)));
                    figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(150f, 150f, 200f, 200f)));

                    // Add the figure to the path
                    path.AddFigure(figure);

                    // Draw the path outline
                    graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), path);

                    // Fill the path using a solid brush
                    using (SolidBrush brush = new SolidBrush())
                    {
                        brush.Color = Aspose.Imaging.Color.CornflowerBlue;
                        brush.Opacity = 100;
                        graphics.FillPath(brush, path);
                    }

                    // Save the image (stream is already bound)
                    image.Save();
                }
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
 * 1. When you need to generate a PNG image with overlapping vector shapes and verify how the winding fill rule renders the interior.
 * 2. When you want to compare the visual result of FillMode.Winding versus FillMode.Alternate for complex figures in a C# graphics application.
 * 3. When you are building a diagram or icon generator that requires precise control over how intersecting shapes are filled.
 * 4. When you need to create a light‑gray background image and draw a black outlined path that is filled with a solid brush using Aspose.Imaging.
 * 5. When you are writing automated tests to ensure that the Aspose.Imaging GraphicsPath correctly applies the winding fill algorithm on streamed PNG output.
 */
