using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = "output_spiral.bmp";

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (string.IsNullOrEmpty(outputDir))
            outputDir = ".";
        Directory.CreateDirectory(outputDir);

        // Create a bound BMP image
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions() { Source = source };
        int width = 800;
        int height = 800;

        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Aspose.Imaging.Color.White);

            // Pen for drawing
            Pen pen = new Pen(Aspose.Imaging.Color.Blue, 2);

            // Spiral parameters
            float centerX = width / 2f;
            float centerY = height / 2f;
            float radius = 10f;
            float angle = 0f;
            int segments = 100;
            float angleStep = (float)(Math.PI / 4); // 45 degrees

            for (int i = 0; i < segments; i++)
            {
                // Starting point
                float x1 = centerX + radius * (float)Math.Cos(angle);
                float y1 = centerY + radius * (float)Math.Sin(angle);

                // First control point
                float cp1Angle = angle + angleStep / 3f;
                float cp1Radius = radius + 5f;
                float x2 = centerX + cp1Radius * (float)Math.Cos(cp1Angle);
                float y2 = centerY + cp1Radius * (float)Math.Sin(cp1Angle);

                // Second control point
                float cp2Angle = angle + 2f * angleStep / 3f;
                float cp2Radius = radius + 10f;
                float x3 = centerX + cp2Radius * (float)Math.Cos(cp2Angle);
                float y3 = centerY + cp2Radius * (float)Math.Sin(cp2Angle);

                // End point
                float x4 = centerX + (radius + 15f) * (float)Math.Cos(angle + angleStep);
                float y4 = centerY + (radius + 15f) * (float)Math.Sin(angle + angleStep);

                // Draw the Bezier segment
                graphics.DrawBezier(pen, x1, y1, x2, y2, x3, y3, x4, y4);

                // Update for next segment
                angle += angleStep;
                radius += 5f;
            }

            // Save the bound image
            canvas.Save();
        }
    }
}