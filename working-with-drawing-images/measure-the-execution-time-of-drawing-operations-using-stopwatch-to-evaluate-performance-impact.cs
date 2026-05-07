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
        try
        {
            // Hardcoded output path
            string outputPath = @"c:\temp\draw_output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a FileCreateSource bound to the output file
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Start measuring drawing time
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                // Perform drawing operations
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(50, 50), new Point(450, 50));
                graphics.DrawRectangle(new Pen(Color.Red, 3), new Rectangle(100, 100, 300, 200));
                graphics.DrawEllipse(new Pen(Color.Blue, 4), new Rectangle(150, 150, 200, 100));

                using (SolidBrush brush = new SolidBrush(Color.Green))
                {
                    graphics.DrawString("Performance Test", new Font("Arial", 24), brush, new PointF(200, 300));
                }

                // Stop timing and output the elapsed time
                stopwatch.Stop();
                Console.WriteLine($"Drawing time: {stopwatch.ElapsedMilliseconds} ms");

                // Save the image (FileCreateSource binds the output path)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}