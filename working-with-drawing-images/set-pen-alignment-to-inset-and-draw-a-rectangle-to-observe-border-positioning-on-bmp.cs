using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output BMP file path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP options and bind to the output file
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 200x200 BMP image
        using (Image image = Image.Create(bmpOptions, 200, 200))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Create a pen with Inset alignment
            Pen pen = new Pen(Color.Blue, 5);
            pen.Alignment = PenAlignment.Inset;

            // Draw a rectangle using the inset-aligned pen
            graphics.DrawRectangle(pen, new Rectangle(20, 20, 160, 160));

            // Save the image (file is already bound to outputPath)
            image.Save();
        }
    }
}