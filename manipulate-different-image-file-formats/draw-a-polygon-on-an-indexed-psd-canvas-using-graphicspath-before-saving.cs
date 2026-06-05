using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = @"c:\temp\output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure PSD options for indexed color mode
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.ChannelsCount = (short)1;          // Indexed images have 1 channel
            psdOptions.ChannelBitsCount = (short)8;      // 8 bits per channel

            // Define a simple palette (red, green, blue)
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue
            });

            // Create the indexed PSD canvas (500x500)
            using (Image image = Image.Create(psdOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a GraphicsPath and a Figure
                GraphicsPath graphicsPath = new GraphicsPath();
                Figure figure = new Figure();

                // Define polygon points
                PointF[] polygonPoints = new PointF[]
                {
                    new PointF(100f, 100f),
                    new PointF(400f, 100f),
                    new PointF(250f, 300f)
                };

                // Add a closed PolygonShape to the figure
                figure.AddShape(new PolygonShape(polygonPoints, true));

                // Add the figure to the path
                graphicsPath.AddFigure(figure);

                // Draw the polygon using a black pen
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

                // Save the PSD image
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
 * 1. When a developer needs to programmatically create a small‑size PSD file in indexed color mode with a custom palette and draw a precise polygon shape using Aspose.Imaging’s GraphicsPath for a web mockup.
 * 2. When an application must generate a Photoshop document for printing proofs that uses a limited color palette and overlays a vector polygon to highlight a specific area.
 * 3. When a batch‑processing tool has to add a colored polygon watermark to multiple PSD files while preserving the indexed color mode to keep the files lightweight.
 * 4. When a game‑asset pipeline requires exporting level‑design outlines as PSD layers with a predefined palette and needs to draw those outlines as polygons via C# and Aspose.Imaging.
 * 5. When a UI‑designer utility creates PSD templates with predefined shape placeholders (such as a triangle) that can later be edited in Photoshop, using the GraphicsPath API.
 */