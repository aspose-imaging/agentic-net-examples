using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Red, 2);
                RectangleF rect = new RectangleF(50.5f, 30.5f, 200.75f, 150.25f);
                graphics.DrawRectangle(pen, rect);

                image.Save(outputPath);
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
 * 1. When a developer needs to overlay a precise, sub‑pixel red rectangle on a PNG image for a UI mock‑up, they can use Graphics.DrawRectangle with a RectangleF to draw the floating‑point shape.
 * 2. When generating automated test screenshots that require exact placement of annotations measured in fractions of a pixel, the code demonstrates how to draw a rectangle with decimal coordinates on an image loaded with Aspose.Imaging.
 * 3. When creating a PDF thumbnail preview where the border must be drawn with a specific thickness and color on a PNG source, the RectangleF overload lets the developer specify floating‑point dimensions for high‑resolution rendering.
 * 4. When building a web service that adds a red bounding box around detected objects in uploaded images, the example shows how to load the image, clear the background, and draw a rectangle using Aspose.Imaging’s Graphics class.
 * 5. When implementing a batch image‑processing script that needs to mark regions of interest with sub‑pixel accuracy in various image formats (e.g., PNG, JPEG), the code illustrates the use of Pen, Color, and RectangleF with Graphics.DrawRectangle.
 */