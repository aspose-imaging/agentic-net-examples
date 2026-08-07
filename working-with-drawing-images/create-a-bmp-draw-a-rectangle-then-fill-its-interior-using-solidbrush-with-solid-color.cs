using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hardcoded)
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a FileCreateSource bound to the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Define canvas size
            int width = 400;
            int height = 300;

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Define rectangle bounds
                Rectangle rect = new Rectangle(50, 50, 300, 200);

                // Draw rectangle outline
                graphics.DrawRectangle(new Pen(Color.Black, 2), rect);

                // Fill rectangle interior with solid color
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, rect);
                }

                // Save the image (file is already bound to outputPath)
                image.Save();
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
 * 1. When a developer needs to generate a BMP thumbnail with a highlighted area for a reporting dashboard, they can use this code to draw and fill a rectangle on a bitmap.
 * 2. When creating a simple placeholder image for a UI component that requires a solid‑color background within a defined border, this snippet shows how to draw and fill a rectangle in C# with Aspose.Imaging.
 * 3. When automating the production of printable labels that include a colored box to emphasize product information, the code can create a BMP file, outline the box, and fill it with a solid brush.
 * 4. When building a test harness that validates image‑processing pipelines by generating known BMP files with specific shapes and colors, this example provides a quick way to draw a filled rectangle.
 * 5. When developing a game asset pipeline that needs to programmatically generate BMP sprites with colored rectangular hit‑boxes, the code demonstrates how to create the file, draw the rectangle outline, and fill its interior using a SolidBrush.
 */