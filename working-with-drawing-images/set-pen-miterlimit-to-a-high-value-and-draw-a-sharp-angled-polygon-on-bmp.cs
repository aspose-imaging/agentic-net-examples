using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\sharp_polygon.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 400x400 BMP image
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics surface
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a pen with a high MiterLimit
                var pen = new Pen(Color.Black, 3);
                pen.MiterLimit = 20f; // high value to handle sharp angles

                // Define a sharp‑angled polygon (a thin triangle)
                var points = new Point[]
                {
                    new Point(200, 10),   // top vertex
                    new Point(210, 200),  // bottom right
                    new Point(190, 200)   // bottom left
                };

                // Draw the polygon
                graphics.DrawPolygon(pen, points);

                // Save the image
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
 * 1. When a developer needs to generate a BMP technical diagram with ultra‑sharp corners—such as a thin triangular marker in engineering schematics—they can set Pen.MiterLimit high and draw the polygon to avoid corner gaps.
 * 2. When creating custom Windows desktop UI icons or toolbar graphics in C#, a high MiterLimit ensures the sharp‑angled polygon renders cleanly in a 24‑bit BMP file.
 * 3. When producing line‑art for laser‑cutting or CNC machining, using Aspose.Imaging to draw a precise acute‑angled shape with a high MiterLimit prevents unwanted bevels in the exported BMP.
 * 4. When exporting GIS map symbols like arrowheads or spike markers to BMP, a developer can use a high Pen.MiterLimit to maintain the integrity of the sharp angles in the polygon.
 * 5. When automating a batch image‑processing pipeline that adds a sharp‑angled watermark or badge to BMP files, setting a high MiterLimit guarantees the polygon’s corners stay crisp across all generated images.
 */