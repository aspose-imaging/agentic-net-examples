using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = @"C:\temp\gauge.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a bound file source
        Source outputSource = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions() { Source = outputSource };

        int width = 400;
        int height = 300;

        // Create the canvas bound to the output file
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);

            // Define the rectangle that bounds the semi‑circular gauge
            Rectangle gaugeRect = new Rectangle(50, 20, 300, 300);

            // Background arc (light gray)
            Pen backgroundPen = new Pen(Color.LightGray, 20);
            graphics.DrawArc(backgroundPen, gaugeRect, 0, 180);

            // Red range (0° to 60°)
            Pen redPen = new Pen(Color.Red, 20);
            graphics.DrawArc(redPen, gaugeRect, 0, 60);

            // Yellow range (60° to 120°)
            Pen yellowPen = new Pen(Color.Yellow, 20);
            graphics.DrawArc(yellowPen, gaugeRect, 60, 60);

            // Green range (120° to 180°)
            Pen greenPen = new Pen(Color.Green, 20);
            graphics.DrawArc(greenPen, gaugeRect, 120, 60);

            // Save the bound image
            canvas.Save();
        }
    }
}