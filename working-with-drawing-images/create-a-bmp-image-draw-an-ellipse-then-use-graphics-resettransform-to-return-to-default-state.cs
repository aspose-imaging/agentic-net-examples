using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = @"c:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new BMP image with the specified dimensions
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a background color
            graphics.Clear(Color.Wheat);

            // Draw an ellipse using a blue pen
            Pen pen = new Pen(Color.Blue, 3);
            graphics.DrawEllipse(pen, new Rectangle(100, 100, 300, 200));

            // Reset any transformations applied to the graphics object
            graphics.ResetTransform();

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}