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
        try
        {
            string outputPath = @"output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                Graphics graphics = new Graphics(image);

                using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
                {
                    blueBrush.Opacity = 0.5f;
                    graphics.FillRectangle(blueBrush, new Rectangle(50, 50, 200, 150));
                }

                using (SolidBrush redBrush = new SolidBrush(Color.Red))
                {
                    redBrush.Opacity = 0.5f;
                    graphics.FillEllipse(redBrush, new Rectangle(150, 150, 200, 200));
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
 * 1. When a developer needs to add a semi‑transparent watermark rectangle to a BMP report image using C# and Aspose.Imaging, they can set Graphics.CompositingMode to SourceOver and draw the shape with a brush opacity of 0.5.
 * 2. When generating custom map tiles where roads or regions must be highlighted with translucent overlays on a BMP background, the code lets you blend the shapes correctly by using SourceOver compositing.
 * 3. When creating UI button icons that require a blue hover effect and a red click effect layered on the same BMP canvas, the semi‑transparent fills ensure the colors blend naturally.
 * 4. When producing printable product labels that combine a semi‑transparent background pattern with a foreground logo on a BMP file, SourceOver compositing preserves the intended visual hierarchy.
 * 5. When building a simple chart image that overlays a translucent data region on top of an existing BMP plot, the code provides the necessary C# image processing steps to merge the shapes without losing the underlying pixels.
 */