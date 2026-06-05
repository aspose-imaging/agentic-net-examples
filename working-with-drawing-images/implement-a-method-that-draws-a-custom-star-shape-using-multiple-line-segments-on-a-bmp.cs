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
            string outputPath = @"c:\temp\star.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options and bind to output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Define image dimensions
            int width = 500;
            int height = 500;

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Parameters for star shape
                float centerX = width / 2f;
                float centerY = height / 2f;
                float outerRadius = 200f;
                float innerRadius = 80f;
                int pointsCount = 5;

                // Calculate star vertices
                Point[] starPoints = new Point[pointsCount * 2 + 1];
                for (int i = 0; i < pointsCount * 2; i++)
                {
                    double angleDeg = i * 36; // 360 / (5*2) = 36 degrees
                    double angleRad = Math.PI * angleDeg / 180.0;
                    float radius = (i % 2 == 0) ? outerRadius : innerRadius;
                    int x = (int)(centerX + radius * Math.Cos(angleRad));
                    int y = (int)(centerY + radius * Math.Sin(angleRad));
                    starPoints[i] = new Point(x, y);
                }
                // Close the star shape by returning to the first point
                starPoints[starPoints.Length - 1] = starPoints[0];

                // Draw the star using line segments
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawLines(pen, starPoints);

                // Save the image (output file already bound)
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
 * 1. When a developer needs to generate a printable badge or certificate with a decorative star emblem saved as a BMP file for legacy printing systems.
 * 2. When an application must create a game asset such as a star‑shaped token or icon on the fly, using C# and Aspose.Imaging to output a 24‑bit BMP for fast loading in older engines.
 * 3. When a reporting tool requires a custom watermark consisting of a multi‑point star drawn with line segments, and the result must be stored as a BMP to embed in PDF or Word documents.
 * 4. When an e‑learning platform wants to programmatically produce star‑shaped progress markers that are saved as BMP images for use in SCORM‑compatible content.
 * 5. When a developer is building a batch process that adds a star‑shaped logo to a series of product images, using Aspose.Imaging’s Graphics API to draw the shape directly onto a BMP canvas before further processing.
 */