using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\output.tiff";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up Tiff options with a bound file source
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(tiffOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Create a graphics path and a figure
                GraphicsPath graphicPath = new GraphicsPath();
                Figure figure = new Figure();

                // Add shapes to the figure
                figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
                figure.AddShape(new PieShape(new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)), 0f, 45f));

                // Add the completed figure to the graphics path
                graphicPath.AddFigure(figure);

                // Draw the path onto the image
                graphics.DrawPath(new Pen(Color.Black, 2), graphicPath);

                // Save the bound image
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
 * 1. When a developer needs to generate a multi‑shape diagram (rectangle, ellipse, pie slice) and save it as a high‑resolution TIFF file for printing or archival purposes.
 * 2. When an application must programmatically create a composite vector graphic on a 500×500 canvas, combine several shapes into a single Figure, and render it with a black outline using Aspose.Imaging for .NET.
 * 3. When a reporting tool requires dynamic generation of chart‑like graphics (e.g., a pie segment inside a bounding box) that are stored in a TIFF image stream for later inclusion in PDF or Word documents.
 * 4. When a GIS or CAD system needs to export custom shape collections as a rasterized TIFF image while preserving the original vector layout through GraphicsPath and Figure objects.
 * 5. When an automated batch process must create placeholder images with geometric placeholders (rectangle, ellipse, pie) for UI mock‑ups, using C# and Aspose.Imaging to ensure consistent file format and color background.
 */