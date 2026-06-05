using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\filled_rectangle.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a PNG image of size 200x200
            PngOptions pngOptions = new PngOptions();
            using (Image image = Image.Create(pngOptions, 200, 200))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Define a blue solid brush and fill the rectangle
                SolidBrush blueBrush = new SolidBrush(Color.Blue);
                graphics.FillRectangle(blueBrush, new Rectangle(20, 20, 160, 160));

                // Define a thick black pen and draw the rectangle outline
                Pen blackPen = new Pen(Color.Black, 5);
                graphics.DrawRectangle(blackPen, new Rectangle(20, 20, 160, 160));

                // Save the image to the specified path
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
 * 1. When generating a PNG thumbnail for a product catalog, a developer can use Aspose.Imaging to draw a filled blue rectangle with a thick black border to highlight the product area.
 * 2. When creating a custom watermark image for PDF reports, the code can produce a 200×200 PNG containing a solid blue rectangle outlined in black as a visual placeholder.
 * 3. When building a UI mock‑up tool that exports design elements to PNG, a developer may need to render a blue rectangle with a black outline to represent a button or panel.
 * 4. When automating the production of test images for computer‑vision algorithms, the snippet can generate a simple PNG with a filled blue rectangle and thick black border to serve as a known geometric shape.
 * 5. When developing a game asset pipeline that requires pre‑rendered sprites, a developer can use this code to create a PNG sprite consisting of a blue rectangle outlined in black for collision debugging.
 */