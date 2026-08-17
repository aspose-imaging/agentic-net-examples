// HOW-TO: Create BMP with Concentric Red and Blue Ellipses in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"c:\temp\concentric_ellipses.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions { Source = source };

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(options, 500, 500))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                int centerX = 250;
                int centerY = 250;
                int maxRadius = 200;
                int step = 20;
                bool toggle = true;

                for (int radius = maxRadius; radius > 0; radius -= step)
                {
                    Aspose.Imaging.Color color = toggle ? Aspose.Imaging.Color.Red : Aspose.Imaging.Color.Blue;
                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(color, 2);
                    int left = centerX - radius;
                    int top = centerY - radius;
                    int diameter = radius * 2;
                    graphics.DrawEllipse(pen, new Aspose.Imaging.Rectangle(left, top, diameter, diameter));
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
 * 1. When you need to generate a BMP file that visualizes nested circles for a scientific diagram or UI element using Aspose.Imaging in a C# application.
 * 2. When an automated report requires a simple graphic of alternating colored rings to illustrate data ranges or thresholds.
 * 3. When a game developer wants to create a background texture of concentric ellipses for a level‑design asset without using external design tools.
 * 4. When a testing framework needs to produce placeholder images with predictable patterns for validating image‑processing pipelines.
 * 5. When a desktop utility must programmatically draw and save custom badge icons that consist of layered ellipses in BMP format.
 */
