using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output directory
        string outputDir = "output";
        Directory.CreateDirectory(outputDir);

        // Radii and corresponding colors
        var radii = new List<int> { 20, 40, 60, 80 };
        var colors = new List<Color> { Color.Red, Color.Green, Color.Blue, Color.Yellow };

        for (int i = 0; i < radii.Count; i++)
        {
            int radius = radii[i];
            Color circleColor = colors[i];

            // Canvas size with a 10‑pixel margin on each side
            int canvasSize = radius * 2 + 20;
            int center = canvasSize / 2;

            string outputPath = Path.Combine(outputDir, $"circle_{radius}.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // BMP creation options bound to the output file
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, canvasSize, canvasSize))
            {
                // Graphics instance for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw a centered filled circle
                using (SolidBrush brush = new SolidBrush(circleColor))
                {
                    graphics.FillEllipse(brush, new Rectangle(center - radius, center - radius, radius * 2, radius * 2));
                }

                // Save the bound image
                image.Save();
            }
        }
    }
}