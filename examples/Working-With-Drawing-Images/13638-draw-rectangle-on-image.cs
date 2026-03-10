using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = @"C:\temp\rectangle.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image with specified dimensions
            using (Image image = Image.Create(pngOptions, 400, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background
                graphics.Clear(Color.White);

                // Draw a blue rectangle at (50,50) with width 200 and height 150
                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));

                // Save changes to the bound stream
                image.Save();
            }
        }
    }
}