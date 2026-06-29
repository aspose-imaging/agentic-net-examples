using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

public class Program
{
    public static void Main()
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\temp\output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a bound FileCreateSource
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics and clear background
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define a rectangle shape
                RectangleF rect = new RectangleF(50f, 50f, 400f, 400f);
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(rect));

                // Add the figure to a graphics path
                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);

                // Fill the rectangle path with a solid brush
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillPath(brush, path);
                }

                // Save the image (output path already bound to the source)
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
 * 1. When creating a PNG thumbnail that displays a gradient‑filled rectangular banner by adding a Figure to a GraphicsPath and filling it with a LinearGradientBrush in a .NET e‑commerce application.
 * 2. When generating a dynamic report chart where a LinearGradientBrush‑filled rectangle, added via GraphicsPath, serves as a legend background in an Aspose.Imaging‑based PDF export.
 * 3. When building a custom UI skin for a Windows Forms app and need to draw a scalable rectangle on a 500×500 canvas by inserting it into a GraphicsPath and applying a LinearGradientBrush for the button background.
 * 4. When producing a marketing email image that requires a smooth color transition inside a rectangular call‑to‑action area, using C# Aspose.Imaging to add the rectangle to a GraphicsPath and fill it with a LinearGradientBrush.
 * 5. When automating the creation of printable certificates and want to add a gradient‑filled rectangular seal or border by adding the shape to a GraphicsPath and rendering it with a LinearGradientBrush in the PNG output.
 */