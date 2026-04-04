using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "output\\random_lines.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a BMP image bound to the output file
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions() { Source = source };

        int width = 800;
        int height = 600;

        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Set background to white
            graphics.Clear(Color.White);

            Random rnd = new Random();
            int lineCount = 20;

            for (int i = 0; i < lineCount; i++)
            {
                // Random line color
                Color lineColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                Pen pen = new Pen(lineColor, 2);

                // Random start and end points within the canvas
                int x1 = rnd.Next(width);
                int y1 = rnd.Next(height);
                int x2 = rnd.Next(width);
                int y2 = rnd.Next(height);

                graphics.DrawLine(pen, x1, y1, x2, y2);
            }

            // Save the bound image
            canvas.Save();
        }
    }
}