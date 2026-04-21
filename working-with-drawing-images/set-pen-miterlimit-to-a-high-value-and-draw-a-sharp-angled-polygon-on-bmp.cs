using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path for the BMP image
        string outputPath = @"C:\temp\sharp_polygon.bmp";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create BMP options with 24 bits per pixel
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            // Use FileCreateSource to specify the file to be created
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new image of size 400x400 pixels
        using (Image image = Image.Create(bmpOptions, 400, 400))
        {
            // Initialize Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Clear the background to white
            graphics.Clear(Color.White);

            // Create a Pen with a relatively thick width
            Pen pen = new Pen(Color.Black, 5);
            // Set a high MiterLimit to allow sharp corners without beveling
            pen.MiterLimit = 10f;

            // Define a sharp‑angled polygon (a thin triangle)
            Point[] points = new Point[]
            {
                new Point(200, 10),   // Top vertex
                new Point(210, 200),  // Bottom‑right vertex
                new Point(190, 200)   // Bottom‑left vertex
            };

            // Draw the polygon using the configured Pen
            graphics.DrawPolygon(pen, points);

            // Save the image (the file is already created by FileCreateSource)
            image.Save();
        }
    }
}