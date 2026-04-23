using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Define output BMP path
        string outputPath = @"c:\temp\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);
        bmpOptions.BitsPerPixel = 24;

        // Create a 400x300 BMP image bound to the file source
        using (Image image = Image.Create(bmpOptions, 400, 300))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Draw a red rectangle covering the whole canvas
            Pen redPen = new Pen(Color.Red, 5);
            graphics.DrawRectangle(redPen, new Rectangle(0, 0, image.Width, image.Height));

            // Set clipping region to a smaller rectangle (100,50,200,150)
            // Subsequent drawing will be limited to this area
            graphics.Clip = new Region(new Rectangle(100, 50, 200, 150));

            // Draw a blue rectangle that will be clipped by the region
            Pen bluePen = new Pen(Color.Blue, 5);
            graphics.DrawRectangle(bluePen, new Rectangle(50, 30, 300, 200));

            // Save the bound image (file is already associated with the source)
            image.Save();
        }
    }
}