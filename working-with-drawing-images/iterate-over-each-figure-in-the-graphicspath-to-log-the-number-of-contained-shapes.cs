using System;
using System.IO;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output path
            string outputPath = @"c:\temp\output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with file source
            PngOptions options = new PngOptions();
            options.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(options, 500, 500))
            {
                // Create a graphics path and figures
                Aspose.Imaging.GraphicsPath graphicspath = new Aspose.Imaging.GraphicsPath();

                Aspose.Imaging.Figure figure1 = new Aspose.Imaging.Figure();
                figure1.AddShape(new Aspose.Imaging.Shapes.EllipseShape(new Aspose.Imaging.RectangleF(50, 50, 300, 300)));
                figure1.AddShape(new Aspose.Imaging.Shapes.RectangleShape(new Aspose.Imaging.RectangleF(100, 100, 200, 200)));

                Aspose.Imaging.Figure figure2 = new Aspose.Imaging.Figure();
                figure2.AddShape(new Aspose.Imaging.Shapes.PieShape(new Aspose.Imaging.RectangleF(150, 150, 250, 250), 0, 90));

                graphicspath.AddFigures(new[] { figure1, figure2 });

                // Iterate over each figure and log the number of shapes it contains
                int index = 0;
                foreach (var fig in graphicspath.Figures)
                {
                    int shapeCount = fig.Shapes.Count();
                    Console.WriteLine($"Figure {index} contains {shapeCount} shape(s).");
                    index++;
                }

                // Draw the path onto the image
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.Wheat);
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), graphicspath);

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
 * 1. When generating a composite PNG report that combines multiple vector drawings, a developer can iterate over each Figure in a GraphicsPath to verify how many shapes were added to each layer before rendering.
 * 2. When debugging a CAD‑to‑image conversion pipeline, logging the shape count per Figure helps identify missing or extra geometry in the Aspose.Imaging.GraphicsPath collection.
 * 3. When building a dynamic infographic where each Figure represents a chart component, counting the shapes per Figure allows the application to adjust layout or scaling based on complexity.
 * 4. When implementing a validation step for user‑drawn annotations saved as PNG files, iterating through the Figures and recording their shape counts ensures the annotation data meets expected constraints.
 * 5. When creating automated tests for a C# image processing library, enumerating Figures and logging their shape counts provides a simple metric to assert that the GraphicsPath was populated correctly across different file formats such as PNG, JPEG, or BMP.
 */