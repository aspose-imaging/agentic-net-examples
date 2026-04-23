using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Create a memory stream to hold the BMP image
        using (MemoryStream memoryStream = new MemoryStream())
        {
            // Set up BMP options with the stream as the output source
            BmpOptions bmpOptions = new BmpOptions
            {
                Source = new StreamSource(memoryStream)
            };

            // Create a 250x250 BMP image
            using (Image image = Image.Create(bmpOptions, 250, 250))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw a Bezier curve with four control points
                Pen pen = new Pen(Color.Blue, 2);
                graphics.DrawBezier(pen,
                    new Point(20, 20),    // Start point
                    new Point(80, 10),    // First control point
                    new Point(150, 200),  // Second control point
                    new Point(230, 230)   // End point
                );

                // Save the image to the bound memory stream
                image.Save();
            }

            // The memory stream now contains the BMP data
            Console.WriteLine($"MemoryStream length: {memoryStream.Length}");
        }
    }
}