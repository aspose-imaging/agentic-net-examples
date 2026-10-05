// HOW-TO: Create Multiple BMP Images with Colored Backgrounds and Centered Ellipse in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);
            int width = 400;
            int height = 400;
            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Cyan, Color.Magenta };
            for (int i = 0; i < colors.Length; i++)
            {
                string outputPath = Path.Combine(outputDir, $"image_{i + 1}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };
                using (BmpImage canvas = (BmpImage)Image.Create(options, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(colors[i]);
                    Pen blackPen = new Pen(Color.Black, 3);
                    int ellipseWidth = width / 2;
                    int ellipseHeight = height / 2;
                    Rectangle rect = new Rectangle((width - ellipseWidth) / 2, (height - ellipseHeight) / 2, ellipseWidth, ellipseHeight);
                    graphics.DrawEllipse(blackPen, rect);
                    canvas.Save();
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
 * 1. When you need to generate a set of BMP icons with different theme colors and a consistent circular logo for a desktop application's UI.
 * 2. When creating test images for automated image‑processing pipelines that require varied background colors and a known shape to validate detection algorithms.
 * 3. When producing placeholder graphics for game assets where each level uses a distinct background hue and a central marker.
 * 4. When preparing a series of printable labels in BMP format, each with a unique background shade and a centered ellipse as a branding element.
 * 5. When building a batch of sample files for a documentation tutorial that demonstrates Aspose.Imaging’s drawing and saving capabilities in C#.
 */
