// HOW-TO: Create 250x250 BMP with Bezier Curve and Save to MemoryStream in C# (Aspose.Imaging for .NET)
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
            using (var memoryStream = new MemoryStream())
            {
                // Set up BMP options with the stream as the destination
                var bmpOptions = new BmpOptions
                {
                    Source = new StreamSource(memoryStream)
                };

                // Create a 250x250 BMP image
                using (var image = Image.Create(bmpOptions, 250, 250))
                {
                    // Initialize graphics for drawing
                    var graphics = new Graphics(image);

                    // Define a blue pen for the Bezier curve
                    var pen = new Pen(Color.Blue, 2);

                    // Draw a Bezier curve with four control points
                    graphics.DrawBezier(
                        pen,
                        new Point(20, 200),   // start point
                        new Point(80, 20),    // first control point
                        new Point(170, 230),  // second control point
                        new Point(230, 50)    // end point
                    );

                    // Save the image into the memory stream
                    image.Save();

                    // Reset stream position if further processing is needed
                    memoryStream.Position = 0;

                    // Example output: length of the generated BMP data
                    Console.WriteLine($"MemoryStream length: {memoryStream.Length} bytes");
                }
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
 * 1. When you need to generate a BMP thumbnail with a custom Bezier overlay for a web API without writing to disk.
 * 2. When you want to create an in‑memory bitmap for dynamic email attachments that include vector‑style curves.
 * 3. When a reporting tool must render a scalable curve on a fixed‑size image before streaming it to a client.
 * 4. When you are building a game asset pipeline that programmatically draws paths onto BMP sprites stored in a memory buffer.
 * 5. When you need to benchmark Aspose.Imaging’s drawing performance by drawing a Bezier curve onto a 250 × 250 BMP held in a MemoryStream.
 */
