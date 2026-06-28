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
            string outputPath = @"C:\temp\progress_ring.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 400;
            int height = 400;

            using (Image canvas = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                int centerX = width / 2;
                int centerY = height / 2;
                int maxRadius = 150;
                int ringCount = 5;
                int ringWidth = 20;
                Color[] colors = new Color[] { Color.Blue, Color.Green, Color.Red, Color.Orange, Color.Purple };

                for (int i = 0; i < ringCount; i++)
                {
                    int radius = maxRadius - i * (ringWidth + 5);
                    int rectSize = radius * 2;
                    Rectangle rect = new Rectangle(centerX - radius, centerY - radius, rectSize, rectSize);
                    Pen pen = new Pen(colors[i % colors.Length], ringWidth);
                    graphics.DrawArc(pen, rect, 0, 270);
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
 * 1. When a developer needs to generate a BMP progress ring image for a Windows desktop application's status indicator using C# and Aspose.Imaging.
 * 2. When a reporting tool requires a lightweight, high‑resolution circular progress graphic that can be saved as a BMP file for inclusion in PDF or Word documents.
 * 3. When an IoT dashboard must display nested arc rings representing multiple sensor thresholds and the image has to be created programmatically on the server side.
 * 4. When a game UI designer wants to create customizable progress rings with different colors and widths that can be exported as BMP assets for use in the game's resource pipeline.
 * 5. When a data‑visualization library needs to render a multi‑layered progress ring on the fly for email newsletters, saving the result as a BMP to ensure compatibility with older email clients.
 */