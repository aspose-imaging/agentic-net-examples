using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                Graphics graphics = new Graphics(image);

                using (SolidBrush rectBrush = new SolidBrush(Color.Blue))
                {
                    rectBrush.Opacity = 0.5f;
                    graphics.FillRectangle(rectBrush, new Rectangle(50, 50, 200, 150));
                }

                using (SolidBrush ellipseBrush = new SolidBrush(Color.Red))
                {
                    ellipseBrush.Opacity = 0.5f;
                    graphics.FillEllipse(ellipseBrush, new Rectangle(150, 100, 200, 150));
                }

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
 * 1. When a developer needs to add a semi‑transparent watermark to a BMP file for branding printed documents, they can use Aspose.Imaging’s Graphics with CompositingMode.SourceOver to overlay a blue rectangle and red ellipse with 50 % opacity.
 * 2. When generating custom map tiles in a GIS application, a developer can draw translucent shapes on a BMP to highlight regions without obscuring the underlying raster data.
 * 3. When creating UI mock‑ups or button icons in a Windows desktop app, a developer can use the code to compose overlapping semi‑transparent shapes on a BMP to preview visual hierarchy.
 * 4. When producing printable reports that require highlighted sections, a developer can employ Aspose.Imaging to draw semi‑transparent rectangles on a BMP background to draw attention to key data.
 * 5. When building a simple game asset pipeline, a developer can use the Graphics.FillEllipse and FillRectangle methods with SourceOver compositing to blend colored shapes into a BMP sprite sheet for later animation.
 */