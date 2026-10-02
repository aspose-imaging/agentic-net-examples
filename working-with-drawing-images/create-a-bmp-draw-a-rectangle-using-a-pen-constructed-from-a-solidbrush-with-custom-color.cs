// HOW-TO: Create BMP Image and Draw Colored Rectangle with Pen in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, 300, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 0, 128, 255)))
                {
                    Pen pen = new Pen(brush, 5);
                    graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 100));
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
 * 1. When you need to generate a BMP thumbnail with a highlighted border for a reporting dashboard.
 * 2. When you want to programmatically add a colored rectangular overlay to a bitmap for a watermark or UI element.
 * 3. When you are creating test images with specific dimensions and custom‑colored shapes for automated visual testing.
 * 4. When you must produce a BMP file with a precise rectangle outline to mark regions of interest in medical imaging software.
 * 5. When you need to export a diagram as a BMP where the rectangle’s color and thickness are defined by a SolidBrush‑based Pen.
 */
