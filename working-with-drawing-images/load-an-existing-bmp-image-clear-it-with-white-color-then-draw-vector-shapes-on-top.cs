// HOW-TO: How To Clear BMP And Draw Shapes With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 5);
                graphics.DrawLine(pen, new Point(10, 10), new Point(200, 10));
                graphics.DrawRectangle(pen, new Rectangle(20, 20, 100, 50));
                graphics.DrawEllipse(pen, new Rectangle(150, 150, 80, 80));

                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(brush, new Rectangle(250, 20, 60, 60));
                }

                image.Save(outputPath);
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
 * 1. When you need to generate a white‑background BMP and overlay custom lines, rectangles, or ellipses for a report or UI thumbnail.
 * 2. When you must programmatically replace the content of an existing BMP with new vector graphics such as logos or annotations in a C# application.
 * 3. When creating test images that combine raster and vector elements, like a blue border and a red filled box, for automated image‑processing validation.
 * 4. When building a server‑side service that receives BMP files, clears them, and draws shapes to highlight regions before saving the result.
 * 5. When preparing printable BMP assets where you need to reset the canvas color and add precise geometric shapes for marketing materials.
 */
