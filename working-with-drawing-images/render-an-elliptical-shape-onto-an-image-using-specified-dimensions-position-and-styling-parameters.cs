using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "ellipse_output.png";

        // Create PNG options and assign a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image with desired dimensions (width: 400, height: 300)
        using (Image image = Image.Create(pngOptions, 400, 300))
        {
            // Initialize graphics object for drawing on the image
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a light gray background
            graphics.Clear(Color.LightGray);

            // Define ellipse position and size
            int ellipseX = 50;      // X-coordinate of upper‑left corner
            int ellipseY = 40;      // Y-coordinate of upper‑left corner
            int ellipseWidth = 300; // Width of bounding rectangle
            int ellipseHeight = 200; // Height of bounding rectangle

            // Create a pen for the ellipse outline (red color, 3‑pixel thickness)
            Pen outlinePen = new Pen(Color.Red, 3);

            // Draw the ellipse outline
            graphics.DrawEllipse(outlinePen, ellipseX, ellipseY, ellipseWidth, ellipseHeight);

            // Create a solid brush for filling the ellipse (semi‑transparent blue)
            SolidBrush fillBrush = new SolidBrush();
            fillBrush.Color = Color.Blue;
            fillBrush.Opacity = 120; // Opacity range: 0‑255

            // Fill the interior of the ellipse
            graphics.FillEllipse(fillBrush, ellipseX, ellipseY, ellipseWidth, ellipseHeight);

            // Save the image to the specified file
            image.Save();
        }
    }
}