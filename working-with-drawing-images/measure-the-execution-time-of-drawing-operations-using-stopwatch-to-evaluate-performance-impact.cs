using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define output path (hard‑coded)
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set PNG options with the stream as source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 500x500 image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.Wheat);

                // Start timing
                var stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();

                // Draw a diagonal line
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(50, 50), new Point(450, 450));

                // Fill a rectangle with a solid brush
                using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillRectangle(brush, new Rectangle(100, 100, 200, 150));
                }

                // Draw an ellipse
                graphics.DrawEllipse(new Pen(Color.Red, 3), new Rectangle(150, 200, 100, 100));

                // Draw a text string
                using (SolidBrush textBrush = new SolidBrush(Color.DarkGreen))
                {
                    graphics.DrawString("Performance Test", new Font("Arial", 24), textBrush, new PointF(120, 350));
                }

                // Stop timing
                stopwatch.Stop();
                Console.WriteLine($"Drawing time: {stopwatch.ElapsedMilliseconds} ms");

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}