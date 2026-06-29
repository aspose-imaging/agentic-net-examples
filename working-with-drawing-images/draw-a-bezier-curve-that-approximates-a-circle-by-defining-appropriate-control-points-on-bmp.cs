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
            // Output BMP file path
            string outputPath = @"C:\temp\bezier_circle.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file create source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 400x400 image
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen for drawing the Bezier curves
                Pen pen = new Pen(Color.Blue, 2);

                // Circle approximation parameters
                float radius = 100f;
                float control = 0.55228475f * radius; // Approximation factor

                // First quadrant
                graphics.DrawBezier(pen,
                    new Point(200, 100),
                    new Point(200 + (int)control, 100),
                    new Point(300, 200 - (int)control),
                    new Point(300, 200));

                // Second quadrant
                graphics.DrawBezier(pen,
                    new Point(300, 200),
                    new Point(300, 200 + (int)control),
                    new Point(200 + (int)control, 300),
                    new Point(200, 300));

                // Third quadrant
                graphics.DrawBezier(pen,
                    new Point(200, 300),
                    new Point(200 - (int)control, 300),
                    new Point(100, 200 + (int)control),
                    new Point(100, 200));

                // Fourth quadrant
                graphics.DrawBezier(pen,
                    new Point(100, 200),
                    new Point(100, 200 - (int)control),
                    new Point(200 - (int)control, 100),
                    new Point(200, 100));
                
                // Save the image (bound to the output file)
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
 * 1. When a developer needs to generate a high‑resolution BMP file containing a mathematically accurate circle for use in legacy Windows applications, they can use this Aspose.Imaging C# code to draw a Bezier‑based circle approximation.
 * 2. When creating test images for automated visual regression testing of image‑processing pipelines, the code provides a reproducible BMP with a blue circle drawn via Bezier curves.
 * 3. When exporting vector‑style graphics to a raster BMP format for inclusion in documentation or reports, the example shows how to calculate control points and render the shape with Aspose.Imaging’s Graphics class.
 * 4. When a game developer wants to pre‑render circular UI elements such as buttons or icons into BMP assets without relying on external design tools, this snippet demonstrates the C# workflow for drawing the circle programmatically.
 * 5. When building a custom barcode or QR‑code generator that requires a circular alignment pattern embedded in a BMP image, the code illustrates how to draw the circle using Bezier curves and save it directly to disk.
 */