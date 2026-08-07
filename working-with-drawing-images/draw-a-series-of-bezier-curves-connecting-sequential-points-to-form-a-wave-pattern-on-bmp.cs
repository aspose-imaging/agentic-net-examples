using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 800;
            int height = 200;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 2);
                int segmentWidth = 100;
                for (int x = 0; x < width; x += segmentWidth)
                {
                    int x1 = x;
                    int y1 = height / 2;

                    int x2 = x + segmentWidth / 4;
                    int y2 = (x / segmentWidth) % 2 == 0 ? height / 2 - 50 : height / 2 + 50;

                    int x3 = x + 3 * segmentWidth / 4;
                    int y3 = y2;

                    int x4 = Math.Min(x + segmentWidth, width);
                    int y4 = height / 2;

                    graphics.DrawBezier(pen,
                        new Point(x1, y1),
                        new Point(x2, y2),
                        new Point(x3, y3),
                        new Point(x4, y4));
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
 * 1. When a developer wants to generate a BMP file that visualizes a sinusoidal wave using Bezier curves for a scientific data report.
 * 2. When an application needs to create a lightweight, device‑independent bitmap header for a custom UI element that displays a blue wave pattern as a background.
 * 3. When a .NET service must programmatically produce a series of smooth waveforms in a BMP image for embedding in email newsletters without relying on external graphics libraries.
 * 4. When an engineering tool requires automated drawing of repetitive wave‑like patterns on a bitmap to simulate signal oscillations for documentation screenshots.
 * 5. When a game developer needs to pre‑render a scrolling wave texture as a BMP asset using Aspose.Imaging’s Graphics.DrawBezier method for later use in the game engine.
 */