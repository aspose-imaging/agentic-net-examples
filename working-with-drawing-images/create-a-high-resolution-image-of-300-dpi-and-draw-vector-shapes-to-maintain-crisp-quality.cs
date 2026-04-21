using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hardcoded)
        string outputPath = "output/high_res_image.png";

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (string.IsNullOrEmpty(outputDir))
        {
            outputDir = ".";
        }
        Directory.CreateDirectory(outputDir);

        // Define image dimensions (e.g., 3000x3000 for high resolution)
        int width = 3000;
        int height = 3000;

        // Create PNG options with a bound file source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(pngOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Define a pen for drawing outlines
            Pen pen = new Pen(Color.Blue, 5);

            // Draw a rectangle
            graphics.DrawRectangle(pen, new Rectangle(100, 100, 2800, 2800));

            // Draw an ellipse inside the rectangle
            graphics.DrawEllipse(pen, new Rectangle(200, 200, 2600, 2600));

            // Draw a diagonal line
            graphics.DrawLine(pen, new Point(100, 100), new Point(2900, 2900));

            // Fill a smaller rectangle with a solid brush
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.LightGray;
                graphics.FillRectangle(brush, new Rectangle(1200, 1200, 600, 600));
            }

            // Save the image (bound to the output file)
            image.Save();
        }
    }
}