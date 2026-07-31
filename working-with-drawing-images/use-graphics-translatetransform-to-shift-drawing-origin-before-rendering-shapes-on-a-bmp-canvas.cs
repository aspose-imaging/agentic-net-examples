using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\translated_output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            bmpOptions.BitsPerPixel = 24;

            // Create a BMP canvas of size 400x300
            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightGray);

                // Shift the drawing origin by (50, 30)
                graphics.TranslateTransform(50f, 30f);

                // Draw a blue rectangle at the translated origin
                graphics.DrawRectangle(new Pen(Color.Blue, 2), new Rectangle(0, 0, 200, 150));

                // Draw a red ellipse inside the rectangle
                graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(0, 0, 200, 150));

                // Fill a smaller green rectangle using a brush
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.Green;
                    brush.Opacity = 100;
                    graphics.FillRectangle(brush, new Rectangle(20, 20, 100, 60));
                }

                // Save the bound image
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
 * 1. When generating a printable BMP report thumbnail and you need to offset the diagram by a margin so the header area remains empty, you can use Graphics.TranslateTransform to shift the drawing origin before rendering shapes.
 * 2. When creating a custom map overlay in C# where geographic features must be positioned relative to a shifted origin on a 400×300 BMP canvas, TranslateTransform lets you draw rectangles and ellipses at the correct offset.
 * 3. When designing a UI sprite sheet in BMP format and want to place icons at a specific offset within the sheet, you can translate the graphics origin before drawing the icon shapes.
 * 4. When adding a semi‑transparent watermark to a BMP image and need the watermark graphics to start away from the top‑left corner, TranslateTransform moves the origin so the rectangle and ellipse are placed correctly.
 * 5. When building a batch image processing utility that adds bordered shapes to existing BMP files and must align them consistently across different image sizes, using TranslateTransform ensures each shape is drawn at the same relative position.
 */