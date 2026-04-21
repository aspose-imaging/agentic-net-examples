using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new image (width: 400, height: 300)
        using (Image image = Image.Create(bmpOptions, 400, 300))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Optional: clear background to white
            graphics.Clear(Color.White);

            // Draw an ellipse inside a 300 × 200 rectangle (positioned at 50,50)
            graphics.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(50, 50, 300, 200));

            // Save the image (writes to the path specified in FileCreateSource)
            image.Save();
        }
    }
}