using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output path (used only for directory creation as per safety rules)
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a 250x250 BMP image
            BmpOptions bmpOptions = new BmpOptions();
            using (Image image = Image.Create(bmpOptions, 250, 250))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define pen and control points for the Bezier curve
                Pen pen = new Pen(Color.Blue, 2);
                Point p1 = new Point(20, 200);
                Point p2 = new Point(80, 20);
                Point p3 = new Point(170, 180);
                Point p4 = new Point(230, 30);

                // Draw the Bezier curve
                graphics.DrawBezier(pen, p1, p2, p3, p4);

                // Save the image to a MemoryStream
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, new BmpOptions());
                    Console.WriteLine($"Memory stream length: {ms.Length}");
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
 * 1. When a developer needs to generate a 250 × 250 BMP thumbnail that contains a custom Bezier curve for a dynamic chart preview in a .NET web application, they can use this Aspose.Imaging code to draw the curve and store the result in a MemoryStream for immediate response.
 * 2. When an automated reporting tool must embed a vector‑style signature line drawn with a Bezier curve into a BMP image before sending it via email, the code creates the image in memory without touching the file system.
 * 3. When a desktop application requires on‑the‑fly creation of a BMP sprite that includes a smooth Bezier path for game UI elements, this snippet shows how to draw the curve and keep the image in a MemoryStream for further processing.
 * 4. When a document conversion service needs to add a decorative blue Bezier underline to a BMP watermark and then stream the modified image to another API, the example demonstrates the necessary C# operations with Aspose.Imaging.
 * 5. When a testing framework wants to validate that the Aspose.Imaging Graphics.DrawBezier method correctly renders control points on a 250 × 250 BMP, the code provides a reproducible in‑memory image for comparison against expected results.
 */