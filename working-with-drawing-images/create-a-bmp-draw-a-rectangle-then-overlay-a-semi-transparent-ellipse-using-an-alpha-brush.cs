// HOW-TO: Create BMP With Rectangle And Semi Transparent Ellipse In C# (Aspose.Imaging for .NET)
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

            int width = 400;
            int height = 300;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen rectPen = new Pen(Color.Blue, 3);
                Rectangle rect = new Rectangle(50, 50, 300, 200);
                graphics.DrawRectangle(rectPen, rect);

                Color ellipseColor = Color.FromArgb(128, 255, 0, 0);
                using (SolidBrush ellipseBrush = new SolidBrush(ellipseColor))
                {
                    graphics.FillEllipse(ellipseBrush, rect);
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
 * 1. When you need to generate a BMP thumbnail that highlights a selected region with a blue border and a semi‑transparent red overlay for a desktop reporting tool.
 * 2. When creating custom UI icons or buttons in a Windows application that require a solid rectangle outline and a translucent ellipse to indicate hover or active states.
 * 3. When producing printable graphics for a legacy system that only accepts BMP files and you must overlay a semi‑transparent shape to mark areas of interest.
 * 4. When building a simple image‑annotation feature that draws a rectangular selection and adds a translucent ellipse as a visual cue for user‑defined regions.
 * 5. When automating the creation of test images for computer‑vision algorithms that need both opaque and alpha‑blended shapes in a BMP format.
 */
