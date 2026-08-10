// HOW-TO: Create Indexed PSD with Polygon Using GraphicsPath in C# (Aspose.Imaging for .NET)
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
            // Output PSD file path (hard‑coded)
            string outputPath = @"C:\temp\output.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.ChannelBitsCount = (short)8;
            psdOptions.ChannelsCount = (short)1;

            // Build a simple grayscale palette (256 colors)
            Color[] paletteColors = new Color[256];
            for (int i = 0; i < 256; i++)
            {
                byte v = (byte)i;
                paletteColors[i] = Color.FromArgb(v, v, v);
            }
            psdOptions.Palette = new ColorPalette(paletteColors);

            // Create a new PSD image (500x500)
            using (Image image = Image.Create(psdOptions, 500, 500))
            {
                // Prepare graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a polygon using GraphicsPath
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Define polygon vertices
                PointF[] points = new PointF[]
                {
                    new PointF(100f, 100f),
                    new PointF(400f, 100f),
                    new PointF(250f, 400f)
                };

                // Add a closed polygon shape to the figure
                figure.AddShape(new PolygonShape(points, true));

                // Add the figure to the path
                path.AddFigure(figure);

                // Draw the polygon with a blue pen
                graphics.DrawPath(new Pen(Color.Blue, 2), path);

                // Save the PSD image (source already bound)
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
 * 1. When you need to generate a PSD file with a limited color palette and draw a custom polygon shape for web‑oriented graphics or thumbnails.
 * 2. When you want to programmatically create an indexed‑color Photoshop document for batch processing in a C# application.
 * 3. When you must add vector‑based polygon annotations to a PSD image before saving it for later editing in Photoshop.
 * 4. When you are building a server‑side image service that outputs lightweight PSD files with grayscale palettes and geometric overlays.
 * 5. When you need to automate the creation of PSD templates that include precise polygon outlines for branding or UI mockups.
 */
