using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\house.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            int canvasWidth = 200;
            int canvasHeight = 200;

            // Set BMP options with file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, canvasWidth, canvasHeight))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen for outlines
                Pen blackPen = new Pen(Color.Black, 2);

                // House body
                int houseX = 50;
                int houseY = 100;
                int houseWidth = 100;
                int houseHeight = 80;
                using (SolidBrush bodyBrush = new SolidBrush(Color.LightGray))
                {
                    graphics.FillRectangle(bodyBrush, new Rectangle(houseX, houseY, houseWidth, houseHeight));
                }
                graphics.DrawRectangle(blackPen, houseX, houseY, houseWidth, houseHeight);

                // Roof (triangle)
                Point[] roofPoints = new Point[]
                {
                    new Point(houseX, houseY),
                    new Point(houseX + houseWidth / 2, houseY - 60),
                    new Point(houseX + houseWidth, houseY)
                };
                using (SolidBrush roofBrush = new SolidBrush(Color.Brown))
                {
                    graphics.FillPolygon(roofBrush, roofPoints);
                }
                graphics.DrawPolygon(blackPen, roofPoints);

                // Chimney
                int chimneyX = houseX + houseWidth - 30;
                int chimneyY = houseY - 60;
                int chimneyWidth = 20;
                int chimneyHeight = 30;
                using (SolidBrush chimneyBrush = new SolidBrush(Color.DarkRed))
                {
                    graphics.FillRectangle(chimneyBrush, new Rectangle(chimneyX, chimneyY, chimneyWidth, chimneyHeight));
                }
                graphics.DrawRectangle(blackPen, chimneyX, chimneyY, chimneyWidth, chimneyHeight);

                // Save the image (bound to FileCreateSource)
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
 * 1. When a developer needs to programmatically create a lightweight BMP icon of a house for a Windows Forms toolbar, this Aspose.Imaging C# example shows how to draw rectangles, triangles, and a chimney on a 24‑bit bitmap.
 * 2. When an automated report generator must embed a simple house illustration into a BMP image for real‑estate listings, the code demonstrates using Graphics, SolidBrush, and Pen objects to render the house shape.
 * 3. When a game developer wants to produce placeholder house sprites as BMP files during prototyping, the example provides a quick way to draw the building components with C# drawing primitives.
 * 4. When a batch image processing script needs to add a custom house watermark to existing BMP files, the sample illustrates creating a new canvas, clearing it, and drawing the house elements before saving.
 * 5. When a learning platform teaches basic image manipulation concepts such as drawing shapes and saving BMP files, this code serves as a practical demonstration of using Aspose.Imaging’s BmpOptions and graphics API.
 */