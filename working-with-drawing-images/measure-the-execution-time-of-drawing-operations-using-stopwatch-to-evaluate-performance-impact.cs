using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // Measure drawing performance
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Draw a line
            graphics.DrawLine(new Pen(Color.Black, 2), new Point(50, 50), new Point(450, 450));

            // Draw a rectangle
            graphics.DrawRectangle(new Pen(Color.Red, 3), new Rectangle(100, 100, 300, 200));

            // Draw an ellipse
            graphics.DrawEllipse(new Pen(Color.Blue, 2), new Rectangle(150, 150, 200, 100));

            // Draw a string with a solid brush
            using (SolidBrush textBrush = new SolidBrush())
            {
                textBrush.Color = Color.DarkGreen;
                graphics.DrawString("Performance Test", new Font("Arial", 24), textBrush, new PointF(200, 250));
            }

            // Stop timing
            stopwatch.Stop();
            Console.WriteLine($"Drawing operations took {stopwatch.ElapsedMilliseconds} ms.");

            // Save the image (file is already bound to the output path)
            image.Save();
        }
    }
}