using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output file path
            string outputPath = @"c:\temp\rectangle.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a graphics path and a figure
                GraphicsPath graphicsPath = new GraphicsPath();
                Figure figure = new Figure();

                // Add a rectangle shape to the figure (x=50, y=50, width=200, height=100)
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 100f)));

                // Add the figure to the graphics path
                graphicsPath.AddFigure(figure);

                // Draw the path with a black pen
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

                // Save the image (output file is already bound to the source)
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
 * 1. When a developer needs to generate a PNG thumbnail with a black rectangular border around a product image for an e‑commerce catalog, they can use Figure.AddShape with a RectangleShape to draw the bounding box on a 500×500 canvas.
 * 2. When creating a printable form preview in C#, a rectangle shape can be added to a Figure to mark a signature field, then saved as a PNG using Aspose.Imaging’s GraphicsPath and Pen objects.
 * 3. When building a UI mock‑up tool that programmatically draws component outlines, developers can define rectangle coordinates with Figure.AddShape to render each element on a white PNG background.
 * 4. When automating QR‑code overlay generation, a developer can draw a precise rectangular frame around the code by adding a RectangleShape to a Figure and saving the result as a PNG file.
 * 5. When writing unit tests for an image‑processing pipeline, a known rectangle can be drawn on a blank canvas using Figure.AddShape, allowing the test to compare the produced PNG against an expected image.
 */