using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"c:\temp\output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 400, 300))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(50, 50, 200, 150);
                graphics.DrawRectangle(pen, rect);

                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Aspose.Imaging.Color.LightBlue;
                    brush.Opacity = 100;
                    graphics.FillRectangle(brush, rect);
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
 * 1. When a developer needs to generate a 24‑bit BMP file and draw a black‑bordered, light‑blue filled rectangle to highlight a region in a Windows desktop preview pane.
 * 2. When an automated reporting service creates BMP charts and uses Aspose.Imaging.Graphics to outline and fill a rectangle that marks a critical data threshold.
 * 3. When a game developer wants to produce a simple BMP sprite with a solid‑color rectangle to visualize a hitbox during debugging.
 * 4. When a batch processing script must add a solid‑filled rectangle overlay to scanned documents saved as BMP to indicate a watermark or signature area.
 * 5. When a legacy application that only supports BMP images requires programmatic drawing of UI components, such as buttons, using a black pen and a solid brush fill.
 */