using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hardcoded)
        string outputPath = "output\\canvas.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file source bound to the output path
        Source source = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = source };

        // Create an 800x600 canvas bound to the file
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, 800, 600))
        {
            // Initialize graphics for the canvas
            Graphics graphics = new Graphics(canvas);

            // Clear the canvas with white background
            graphics.Clear(Color.White);

            // Create a red pen with thickness 2
            Pen redPen = new Pen(Color.Red, 2);

            // Draw a red ellipse within the specified rectangle
            graphics.DrawEllipse(redPen, new Rectangle(100, 50, 600, 500));

            // Save the bound image
            canvas.Save();
        }
    }
}