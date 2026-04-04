using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\rotated_rectangle.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false) // Destination file
        };

        // Create a new image with the specified dimensions
        using (Image image = Image.Create(bmpOptions, 400, 400))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a background color
            graphics.Clear(Aspose.Imaging.Color.Wheat);

            // Draw a blue rectangle (no rotation applied yet)
            graphics.DrawRectangle(
                new Pen(Aspose.Imaging.Color.Blue, 3),
                new Rectangle(50, 50, 200, 100));

            // Rotate subsequent drawings by 45 degrees around the image center
            graphics.TranslateTransform(image.Width / 2f, image.Height / 2f);
            graphics.RotateTransform(45);
            graphics.TranslateTransform(-image.Width / 2f, -image.Height / 2f);

            // Draw a red rectangle after rotation
            graphics.DrawRectangle(
                new Pen(Aspose.Imaging.Color.Red, 3),
                new Rectangle(150, 150, 200, 100));

            // Save the image to the specified file
            image.Save();
        }
    }
}