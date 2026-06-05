using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output file path
            string outputPath = @"c:\temp\output.tiff";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file stream for the output image
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Set up Tiff options with the stream as source
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new StreamSource(stream);

                // Create a new image with specified dimensions
                using (Image image = Image.Create(tiffOptions, 500, 500))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.Wheat);

                    // Create a graphics path and a figure
                    GraphicsPath graphicspath = new GraphicsPath();
                    Figure figure = new Figure();

                    // Add shapes to the figure
                    figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                    figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
                    figure.AddShape(new PieShape(new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)), 0f, 45f));

                    // Add the completed figure to the graphics path
                    graphicspath.AddFigure(figure);

                    // Draw the path onto the image
                    graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

                    // Save the image
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
 * 1. When a developer needs to generate a multi‑shape vector illustration (rectangle, ellipse, pie slice) and embed it into a high‑resolution TIFF file for printing or archival purposes, they can use GraphicsPath.AddFigure to combine the shapes into a single path before drawing.
 * 2. When building a custom watermark or stamp that consists of several geometric elements and must be applied to scanned documents saved as TIFF images, the code shows how to assemble those elements into a Figure and add it to a GraphicsPath for consistent rendering.
 * 3. When creating a dynamic map overlay where multiple shapes represent zones of interest and the final image must be saved in a lossless TIFF format for GIS analysis, developers can use AddFigure to merge the shapes into one path and draw it with a Pen.
 * 4. When producing a batch of product labels that include a rectangular border, a circular logo, and a pie‑chart segment, the AddFigure method lets developers combine these shapes into a single path and render them onto a TIFF canvas in a C# application.
 * 5. When generating a printable certificate that contains a combination of geometric frames and decorative elements stored as a TIFF file, using GraphicsPath.AddFigure simplifies the process of grouping the shapes into one figure before drawing them with Aspose.Imaging for .NET.
 */