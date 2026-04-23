using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output file path (hardcoded)
        string outputPath = "Output\\rotated.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, 400, 300))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with white background
            graphics.Clear(Color.White);

            // Draw the first rectangle
            Pen pen = new Pen(Color.Blue, 3);
            graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 100));

            // Rotate subsequent drawings by 45 degrees
            graphics.RotateTransform(45f);

            // Draw a second rectangle (will be rotated)
            graphics.DrawRectangle(pen, new Rectangle(150, 100, 200, 100));

            // Save the image (output path is already bound)
            image.Save();
        }
    }
}