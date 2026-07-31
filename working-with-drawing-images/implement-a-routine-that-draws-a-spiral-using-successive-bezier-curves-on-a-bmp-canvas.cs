using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"output.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create BMP options with bound file source
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions { Source = source };

            // Define canvas size
            int width = 800;
            int height = 800;

            // Create canvas bound to the output file
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Spiral parameters
                int turns = 5;
                int segmentsPerTurn = 30;
                int totalSegments = turns * segmentsPerTurn;
                double angleStep = Math.PI * 2 / segmentsPerTurn;
                double a = 0.0;          // initial radius
                double b = 5.0;          // radius growth factor

                int centerX = width / 2;
                int centerY = height / 2;

                Pen pen = new Pen(Color.Black, 1);

                for (int i = 0; i < totalSegments; i++)
                {
                    double theta1 = i * angleStep;
                    double theta2 = (i + 1) * angleStep;

                    double r1 = a + b * theta1;
                    double r2 = a + b * theta2;

                    // Start and end points
                    int x1 = (int)(centerX + r1 * Math.Cos(theta1));
                    int y1 = (int)(centerY + r1 * Math.Sin(theta1));
                    int x4 = (int)(centerX + r2 * Math.Cos(theta2));
                    int y4 = (int)(centerY + r2 * Math.Sin(theta2));

                    // Control points at 1/3 and 2/3 of the segment
                    double thetaC1 = theta1 + angleStep / 3.0;
                    double thetaC2 = theta1 + 2.0 * angleStep / 3.0;
                    double rC1 = a + b * thetaC1;
                    double rC2 = a + b * thetaC2;

                    int x2 = (int)(centerX + rC1 * Math.Cos(thetaC1));
                    int y2 = (int)(centerY + rC1 * Math.Sin(thetaC1));
                    int x3 = (int)(centerX + rC2 * Math.Cos(thetaC2));
                    int y3 = (int)(centerY + rC2 * Math.Sin(thetaC2));

                    graphics.DrawBezier(pen,
                        new Point(x1, y1),
                        new Point(x2, y2),
                        new Point(x3, y3),
                        new Point(x4, y4));
                }

                // Save the bound image
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
 * 1. When a developer needs to generate a high‑resolution BMP illustration of a mathematical spiral for scientific reports or engineering documentation, they can use this routine to draw the curve with precise Bezier segments.
 * 2. When creating custom printable patterns such as spiral‑based background textures for packaging or label designs, the code provides a programmatic way to render the pattern directly into a BMP file.
 * 3. When building a data‑visualization tool that converts algorithmic paths into raster images, the spiral drawing example shows how to map polar coordinates to pixel positions using Aspose.Imaging graphics.
 * 4. When automating the production of test images for image‑processing pipelines—e.g., verifying edge‑detection or curve‑fitting algorithms—the generated BMP spiral serves as a reproducible benchmark.
 * 5. When developing a Windows desktop application that needs to export user‑drawn spirals or decorative elements as BMP files without relying on GDI+, this code demonstrates the required C# operations with Aspose.Imaging.
 */