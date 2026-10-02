// HOW-TO: Draw Parallel Lines At 45 Degrees On A BMP With C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 500;
            int height = 500;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath);
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Pen pen = new Pen(Color.Black, 2);
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                double angleDeg = 45;
                double angleRad = angleDeg * Math.PI / 180.0;
                double cos = Math.Cos(angleRad);
                double sin = Math.Sin(angleRad);
                int spacing = 20;

                double length = Math.Sqrt(width * width + height * height) * 2;

                for (int i = -height; i < width + height; i += spacing)
                {
                    double offset = i;
                    double x1 = offset * (-sin);
                    double y1 = offset * cos;
                    double x2 = x1 + cos * length;
                    double y2 = y1 + sin * length;

                    graphics.DrawLine(pen, (int)Math.Round(x1), (int)Math.Round(y1), (int)Math.Round(x2), (int)Math.Round(y2));
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
 * 1. When you need to generate a patterned background image, such as diagonal hatch lines, for a BMP file in a C# application.
 * 2. When creating printable engineering drawings that require evenly spaced guide lines at a specific angle using Aspose.Imaging.
 * 3. When building a custom watermark or security pattern overlay on a bitmap before saving it to disk.
 * 4. When developing a game or UI asset that uses tiled line textures generated programmatically at runtime.
 * 5. When automating the production of test images to verify image‑processing algorithms that expect parallel line patterns at a given angle.
 */
