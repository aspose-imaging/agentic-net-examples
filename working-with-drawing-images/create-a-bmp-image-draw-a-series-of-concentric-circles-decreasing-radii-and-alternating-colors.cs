// HOW-TO: Create BMP with Concentric Red and Blue Circles in C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.bmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                int centerX = width / 2;
                int centerY = height / 2;
                int maxRadius = 200;
                int step = 20;
                bool toggle = false;

                for (int radius = maxRadius; radius >= step; radius -= step)
                {
                    Aspose.Imaging.Color color = toggle ? Aspose.Imaging.Color.Red : Aspose.Imaging.Color.Blue;
                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        int x = centerX - radius;
                        int y = centerY - radius;
                        int diameter = radius * 2;
                        graphics.FillEllipse(brush, new Rectangle(x, y, diameter, diameter));
                    }
                    toggle = !toggle;
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
 * 1. When you need to generate a BMP file that visualizes layered rings for a scientific diagram or UI element.
 * 2. When an application must programmatically create a background pattern of alternating colored circles for a game or visualization.
 * 3. When you want to produce a printable bitmap badge with concentric circles for branding or certification stamps.
 * 4. When you need to automate the creation of test images with known geometry to validate image‑processing algorithms.
 * 5. When a reporting tool requires a simple BMP chart showing concentric circles to illustrate data ranges or thresholds.
 */
