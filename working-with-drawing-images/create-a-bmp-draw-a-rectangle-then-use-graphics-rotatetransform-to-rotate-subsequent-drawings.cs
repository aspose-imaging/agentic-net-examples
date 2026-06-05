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
            // Output file path (hard‑coded)
            string outputPath = "Output/output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options and bind the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 400×400 BMP image
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Draw first rectangle (blue)
                Pen bluePen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(bluePen, new Rectangle(50, 50, 200, 100));

                // Rotate subsequent drawings by 45 degrees
                graphics.RotateTransform(45);

                // Draw second rectangle (red) – will appear rotated
                Pen redPen = new Pen(Color.Red, 3);
                graphics.DrawRectangle(redPen, new Rectangle(50, 200, 200, 100));

                // Save the image (file is already bound via FileCreateSource)
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
 * 1. When generating a printable BMP report that includes a rotated rectangle overlay to highlight a specific data region, developers can use this code to draw and rotate the shape.
 * 2. When creating a simple game sprite sheet in BMP format where UI elements need to appear at a 45‑degree angle, this code provides the necessary drawing and rotation operations.
 * 3. When building a diagnostic tool that outputs a BMP diagram with a rotated rectangular indicator to show sensor coverage, the Graphics.RotateTransform method enables the required orientation.
 * 4. When automating the production of BMP certificates that require a rotated border rectangle for branding purposes, developers can apply this code to add the rotated element.
 * 5. When developing a batch image processor that adds a rotated rectangular overlay to BMP files for watermarking, this example demonstrates the essential C# drawing and rotation steps.
 */