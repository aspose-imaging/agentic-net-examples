using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create BMP options with a file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Define canvas size
        int canvasWidth = 500;
        int canvasHeight = 300;

        // Create the BMP canvas (bound to the output file)
        using (Image canvas = Image.Create(bmpOptions, canvasWidth, canvasHeight))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);

            // Create a pen with rounded line caps for smooth curves
            Pen pen = new Pen(Color.Blue, 5);
            pen.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Flat);

            // Define points for the smooth curve
            Point[] curvePoints = new Point[]
            {
                new Point(50, 200),
                new Point(150, 50),
                new Point(250, 200),
                new Point(350, 50),
                new Point(450, 200)
            };

            // Draw the curve
            graphics.DrawCurve(pen, curvePoints);

            // Save the bound image
            canvas.Save();
        }
    }
}