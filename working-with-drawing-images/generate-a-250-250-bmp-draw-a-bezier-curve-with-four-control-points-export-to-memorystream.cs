using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a memory stream to hold the BMP data
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Set up the source and BMP options
                Source source = new StreamSource(memoryStream);
                BmpOptions bmpOptions = new BmpOptions { Source = source };

                // Create a 250×250 BMP canvas
                using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, 250, 250))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(canvas);

                    // Define a blue pen
                    Pen pen = new Pen(Color.Blue, 2);

                    // Define four control points for the Bezier curve
                    Point p1 = new Point(20, 200);
                    Point p2 = new Point(70, 50);
                    Point p3 = new Point(180, 50);
                    Point p4 = new Point(230, 200);

                    // Draw the Bezier curve
                    graphics.DrawBezier(pen, p1, p2, p3, p4);

                    // Save the image to the bound memory stream
                    canvas.Save();
                }

                // Reset stream position for any further processing
                memoryStream.Position = 0;
                Console.WriteLine($"MemoryStream length: {memoryStream.Length} bytes");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a small 250 × 250 BMP thumbnail with a custom Bezier curve for embedding in a Windows desktop application's UI without writing to disk.
 * 2. When an automated reporting tool must create in‑memory BMP graphics of vector shapes (e.g., a Bezier curve) to attach to email notifications using C# and Aspose.Imaging.
 * 3. When a game engine requires a procedural texture created at runtime, such as a 250 × 250 BMP containing a smooth curve, and the texture must be streamed directly to GPU memory via a MemoryStream.
 * 4. When a web service has to return a BMP image of a hand‑drawn curve as a byte array response for client‑side rendering in a browser or mobile app.
 * 5. When a unit test validates that the Aspose.Imaging drawing API correctly renders a Bezier curve by comparing the generated BMP bytes stored in a MemoryStream against an expected baseline.
 */