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
            // Output file path (hard‑coded)
            string outputPath = "output_spiral.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a file source bound to the output path
            Source source = new FileCreateSource(outputPath, false);

            // BMP options with the source
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            // Canvas size
            int width = 800;
            int height = 800;

            // Create BMP canvas bound to the file source
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Pen for the spiral
                Pen pen = new Pen(Color.Blue, 2);

                // Spiral parameters
                float centerX = width / 2f;
                float centerY = height / 2f;
                float startRadius = 10f;
                float radiusIncrement = 5f;
                float angleStep = 0.5f; // radians per segment
                int segments = 100;

                // Draw successive Bezier curves to form a spiral
                for (int i = 0; i < segments; i++)
                {
                    float angle1 = i * angleStep;
                    float angle2 = (i + 1) * angleStep;

                    float r1 = startRadius + i * radiusIncrement;
                    float r2 = startRadius + (i + 1) * radiusIncrement;

                    // End points of the Bezier segment
                    float x1 = centerX + r1 * (float)Math.Cos(angle1);
                    float y1 = centerY + r1 * (float)Math.Sin(angle1);
                    float x4 = centerX + r2 * (float)Math.Cos(angle2);
                    float y4 = centerY + r2 * (float)Math.Sin(angle2);

                    // Approximate control points for smooth curvature
                    float ctrlDist = (float)(Math.PI * (r1 + r2) / 2 * angleStep / 2);
                    float midAngle = angle1 + angleStep / 2f;

                    float x2 = centerX + (r1 + ctrlDist) * (float)Math.Cos(midAngle);
                    float y2 = centerY + (r1 + ctrlDist) * (float)Math.Sin(midAngle);
                    float x3 = centerX + (r2 - ctrlDist) * (float)Math.Cos(midAngle);
                    float y3 = centerY + (r2 - ctrlDist) * (float)Math.Sin(midAngle);

                    // Draw the Bezier segment
                    graphics.DrawBezier(pen, x1, y1, x2, y2, x3, y3, x4, y4);
                }

                // Save the bound image (no need to specify options again)
                canvas.Save();
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
 * 1. When a developer needs to generate a BMP file that visualizes a mathematical spiral using successive Bezier curves for documentation or testing of vector‑to‑raster rendering in Aspose.Imaging for .NET.
 * 2. When an engineering team wants to create a high‑resolution spiral pattern as a background image for a UI prototype, leveraging C# Graphics, Pen, and Aspose.Imaging raster image creation.
 * 3. When a scientific application must export a spiral trajectory diagram to a BMP file for inclusion in research papers, using Aspose.Imaging’s file source and Bezier curve drawing.
 * 4. When a game developer requires a procedural texture of a spiral to be saved as a BMP asset during build time, employing Aspose.Imaging’s RasterImage and Graphics classes.
 * 5. When a data‑visualization library needs to demonstrate custom curve rendering by drawing a spiral with incremental radius and angle steps into a BMP canvas using C# and Aspose.Imaging.
 */