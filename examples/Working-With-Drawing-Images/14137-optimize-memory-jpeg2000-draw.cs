using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output JPEG2000 file path
        string outputPath = "output.jp2";

        // Configure JPEG2000 options with a memory limit (50 MB)
        Jpeg2000Options jp2Options = new Jpeg2000Options
        {
            BufferSizeHint = 50,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a 1000x1000 JPEG2000 image canvas
        using (Image image = Image.Create(jp2Options, 1000, 1000))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background
            graphics.Clear(Color.LightGray);

            // Draw a blue rectangle border
            graphics.DrawRectangle(new Pen(Color.Blue, 5), new Rectangle(100, 100, 800, 800));

            // Draw a red diagonal line
            graphics.DrawLine(new Pen(Color.Red, 3), new Point(100, 100), new Point(900, 900));

            // Fill a green ellipse
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.Green;
                brush.Opacity = 100;
                graphics.FillEllipse(brush, new Rectangle(300, 300, 400, 400));
            }

            // Save the image (already bound to the output file)
            image.Save();
        }

        Console.WriteLine("JPEG2000 image created with optimized memory usage.");
    }
}