using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define output files with their background colors
        var outputs = new[]
        {
            new { Path = @"C:\temp\red.bmp", Bg = Color.Red },
            new { Path = @"C:\temp\green.bmp", Bg = Color.Green },
            new { Path = @"C:\temp\blue.bmp", Bg = Color.Blue },
            new { Path = @"C:\temp\yellow.bmp", Bg = Color.Yellow },
            new { Path = @"C:\temp\cyan.bmp", Bg = Color.Cyan }
        };

        const int width = 500;
        const int height = 500;
        const int ellipseWidth = 300;
        const int ellipseHeight = 200;

        foreach (var item in outputs)
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(item.Path));

            // Create BMP options bound to the output file
            Source src = new FileCreateSource(item.Path, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = src };

            // Create a bound canvas
            using (Image canvas = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Fill the background with the specified color
                graphics.Clear(item.Bg);

                // Calculate centered ellipse rectangle
                int x = (width - ellipseWidth) / 2;
                int y = (height - ellipseHeight) / 2;
                Rectangle ellipseRect = new Rectangle(x, y, ellipseWidth, ellipseHeight);

                // Draw a black ellipse
                Pen blackPen = new Pen(Color.Black, 2);
                graphics.DrawEllipse(blackPen, ellipseRect);

                // Save the bound image
                canvas.Save();
            }
        }
    }
}