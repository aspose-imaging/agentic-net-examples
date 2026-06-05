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
            string outputPath = @"c:\temp\output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen outerPen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(outerPen, new Rectangle(10, 10, 380, 280));

                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.Red;
                    brush.Opacity = 100;
                    graphics.FillEllipse(brush, new Rectangle(60, 60, 180, 130));
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
 * 1. When a developer needs to generate a 24‑bit BMP image with a blue border and restrict all subsequent drawing to a rectangular region using Graphics.SetClip, this code provides a quick solution.
 * 2. When an application must programmatically add a colored ellipse watermark that appears only inside a defined rectangle on a BMP file, the clipping technique shown is ideal.
 * 3. When a batch‑processing tool draws multiple geometric shapes on a bitmap but wants to limit later shapes to a specific area for performance and visual consistency, the SetClip approach is perfect.
 * 4. When a CAD or mapping system exports a viewport snapshot as a BMP and uses Graphics.SetClip to ensure that only objects within the selected viewport are rendered, this example demonstrates the required steps.
 * 5. When a game asset pipeline creates sprite sheets in BMP format and needs to clip each sprite to its bounding rectangle before filling it with colors, the code illustrates how to achieve that.
 */