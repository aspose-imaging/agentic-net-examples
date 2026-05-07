using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a memory stream to hold the BMP data
            using (MemoryStream ms = new MemoryStream())
            {
                // Configure BMP options with the stream as the output source
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(ms);

                // Create a 250x250 BMP canvas
                using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 250, 250))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    // Define a blue pen for the Bezier curve
                    Pen pen = new Pen(Color.Blue, 2);

                    // Define four control points for the Bezier spline
                    Point p1 = new Point(20, 200);
                    Point p2 = new Point(70, 20);
                    Point p3 = new Point(180, 20);
                    Point p4 = new Point(230, 200);

                    // Draw the Bezier curve
                    graphics.DrawBezier(pen, p1, p2, p3, p4);

                    // Save the image to the bound memory stream
                    canvas.Save();
                }

                // Reset stream position if further processing is needed
                ms.Position = 0;
                Console.WriteLine($"MemoryStream length: {ms.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}