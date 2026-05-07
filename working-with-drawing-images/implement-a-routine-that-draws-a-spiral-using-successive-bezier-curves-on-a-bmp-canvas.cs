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
            // Output file path
            string outputPath = "spiral.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create BMP options with a file source
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            // Canvas size
            int width = 800;
            int height = 800;

            // Create the image canvas
            using (Image image = Image.Create(options, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen for drawing
                Pen pen = new Pen(Color.Blue, 2);

                // Spiral parameters
                float centerX = width / 2f;
                float centerY = height / 2f;
                float radius = 5f;
                float angle = 0f;
                float angleStep = (float)(Math.PI / 4); // 45 degrees
                int segments = 30;

                // Starting point
                float x0 = centerX + radius * (float)Math.Cos(angle);
                float y0 = centerY + radius * (float)Math.Sin(angle);

                for (int i = 0; i < segments; i++)
                {
                    // Increment radius and angle for the next point
                    radius += 5f;
                    angle += angleStep;

                    // End point of the Bezier segment
                    float x3 = centerX + radius * (float)Math.Cos(angle);
                    float y3 = centerY + radius * (float)Math.Sin(angle);

                    // Control points (simple approximation)
                    float ctrlAngle = angle - angleStep / 2f;
                    float ctrlRadius = radius - 2.5f;
                    float x1 = centerX + ctrlRadius * (float)Math.Cos(ctrlAngle);
                    float y1 = centerY + ctrlRadius * (float)Math.Sin(ctrlAngle);
                    float x2 = x1; // Using the same control point for simplicity
                    float y2 = y1;

                    // Draw the Bezier curve segment
                    graphics.DrawBezier(
                        pen,
                        new Point((int)x0, (int)y0),
                        new Point((int)x1, (int)y1),
                        new Point((int)x2, (int)y2),
                        new Point((int)x3, (int)y3));

                    // Prepare for next segment
                    x0 = x3;
                    y0 = y3;
                }

                // Save the image (bound to the file source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}