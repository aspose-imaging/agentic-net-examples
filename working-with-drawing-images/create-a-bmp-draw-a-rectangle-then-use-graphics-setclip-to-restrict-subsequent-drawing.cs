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
            string outputPath = @"C:\Temp\output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image canvas = Image.Create(bmpOptions, 400, 300))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                Pen blackPen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(blackPen, new Rectangle(50, 50, 300, 200));

                graphics.Clip = new Region(new Rectangle(100, 100, 200, 100));

                using (SolidBrush redBrush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(redBrush, new Rectangle(80, 80, 250, 150));
                }

                canvas.Save();
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
 * 1. When a developer needs to generate a 24‑bit BMP report thumbnail that highlights a specific area by drawing a rectangle border and filling only the clipped region with a color.
 * 2. When creating a printable form template in C# where a rectangular outline is drawn and subsequent background filling is limited to a defined clipping region using Graphics.SetClip.
 * 3. When building a simple image‑masking tool that restricts drawing operations to a designated rectangle to prevent overwriting surrounding graphics in a BMP file.
 * 4. When producing a UI mock‑up that demonstrates how a selected area of a bitmap can be emphasized by clipping later drawing commands to that area.
 * 5. When automating the generation of annotated screenshots where a red overlay is applied only inside a predefined rectangle to draw attention to a specific UI element.
 */