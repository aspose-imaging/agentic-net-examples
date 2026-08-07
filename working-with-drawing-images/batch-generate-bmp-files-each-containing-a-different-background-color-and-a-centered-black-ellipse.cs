using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output directory
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Background colors for each image
            Color[] bgColors = new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow,
                Color.Cyan
            };

            int width = 400;
            int height = 400;
            int ellipseWidth = 200;
            int ellipseHeight = 200;
            int ellipseX = (width - ellipseWidth) / 2;
            int ellipseY = (height - ellipseHeight) / 2;

            for (int i = 0; i < bgColors.Length; i++)
            {
                string outputPath = Path.Combine(outputDir, $"image_{i + 1}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options with bound source
                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };

                using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
                {
                    // Initialize graphics
                    Graphics graphics = new Graphics(canvas);

                    // Set background color
                    graphics.Clear(bgColors[i]);

                    // Draw centered black ellipse
                    using (SolidBrush blackBrush = new SolidBrush(Color.Black))
                    {
                        graphics.FillEllipse(blackBrush, new Rectangle(ellipseX, ellipseY, ellipseWidth, ellipseHeight));
                    }

                    // Save the bound image
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
 * 1. When a developer needs to generate a set of BMP icons with different background colors and a centered black ellipse for a Windows desktop application’s theme palette.
 * 2. When an automated build script must create test BMP images to verify image‑processing pipelines that handle solid color backgrounds and vector shapes using Aspose.Imaging for .NET.
 * 3. When a reporting tool requires batch‑produced BMP charts where each chart uses a distinct background hue and a consistent black ellipse as a placeholder for data visualization.
 * 4. When a game asset pipeline needs to pre‑render BMP sprites with varying background colors and a centered black ellipse to serve as collision masks or UI elements.
 * 5. When a documentation generator wants to embed example BMP files showing how C# graphics operations like Clear and FillEllipse work with Aspose.Imaging’s RasterImage class.
 */