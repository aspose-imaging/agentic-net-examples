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
            string outputDir = "Thumbnails";
            Directory.CreateDirectory(outputDir);

            for (int i = 0; i < 100; i++)
            {
                string outputPath = Path.Combine(outputDir, $"thumb_{i}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };

                using (Image canvas = Image.Create(options, 100, 100))
                {
                    Graphics graphics = new Graphics(canvas);

                    int radius = 40;
                    int centerX = 50;
                    int centerY = 50;
                    Rectangle bounds = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);

                    using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
                    {
                        graphics.FillEllipse(blueBrush, bounds);
                    }

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
 * 1. When a developer needs to automatically generate a batch of 100 × 100 BMP thumbnail icons with a centered blue circle for a Windows desktop application's toolbar.
 * 2. When an automated test suite must create placeholder BMP images of a fixed size to verify that image‑processing pipelines correctly handle 100 × 100 pixel graphics.
 * 3. When a content‑management system requires pre‑rendered BMP thumbnails with a simple blue circle logo to display before the actual user‑uploaded pictures are processed.
 * 4. When a game developer wants to produce a set of 100 × 100 BMP sprites containing a blue circular marker for use as minimap icons or UI elements.
 * 5. When a reporting tool needs to embed uniform 100 × 100 BMP thumbnails with a blue circle into PDF or Excel documents to illustrate data points without relying on external image assets.
 */