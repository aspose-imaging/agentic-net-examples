using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path (hardcoded)
        string outputPath = @"C:\temp\custom_logo.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create BMP options with a file create source bound to the output path
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Define canvas size
        int width = 500;
        int height = 400;

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Draw a red rectangle (logo outer border)
            Pen redPen = new Pen(Color.Red, 5);
            graphics.DrawRectangle(redPen, new Rectangle(50, 50, 400, 300));

            // Draw a blue ellipse inside the rectangle
            Pen bluePen = new Pen(Color.Blue, 3);
            graphics.DrawEllipse(bluePen, new Rectangle(100, 100, 300, 200));

            // Draw a green smaller rectangle
            Pen greenPen = new Pen(Color.Green, 2);
            graphics.DrawRectangle(greenPen, new Rectangle(150, 150, 200, 100));

            // Draw a purple ellipse overlapping the previous shapes
            Pen purplePen = new Pen(Color.Purple, 4);
            graphics.DrawEllipse(purplePen, new Rectangle(200, 120, 150, 150));

            // Save the image (output path already bound)
            image.Save();
        }
    }
}