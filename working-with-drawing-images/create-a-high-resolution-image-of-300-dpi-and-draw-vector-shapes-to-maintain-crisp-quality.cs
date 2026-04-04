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
        // Output file path (hardcoded)
        string outputPath = @"C:\temp\highres.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a bound file source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Define image size for 300 DPI (e.g., 8\" x 6\" => 2400 x 1800 pixels)
        int width = 2400;
        int height = 1800;

        // Create the image bound to the output file
        using (Image image = Image.Create(pngOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Draw a red rectangle border
            Pen redPen = new Pen(Color.Red, 5);
            graphics.DrawRectangle(redPen, new Rectangle(100, 100, width - 200, height - 200));

            // Draw a blue ellipse inside the rectangle
            Pen bluePen = new Pen(Color.Blue, 3);
            graphics.DrawEllipse(bluePen, new Rectangle(150, 150, width - 300, height - 300));

            // Draw a green diagonal line
            Pen greenPen = new Pen(Color.Green, 2);
            graphics.DrawLine(greenPen, new Point(100, 100), new Point(width - 100, height - 100));

            // Draw centered text using a solid brush
            using (SolidBrush textBrush = new SolidBrush(Color.Black))
            {
                Font font = new Font("Arial", 48);
                graphics.DrawString("High DPI Image", font, textBrush, new PointF(width / 2 - 200, height / 2));
            }

            // Save the image (file is already bound to the output path)
            image.Save();
        }
    }
}