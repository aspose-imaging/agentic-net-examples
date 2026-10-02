// HOW-TO: Create a Spiral Drawing With Bezier Curves On BMP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string outputPath = "spiral.bmp";
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                int width = 800;
                int height = 800;

                var bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                using (var image = (RasterImage)Image.Create(bmpOptions, width, height))
                {
                    var graphics = new Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    var pen = new Pen(Aspose.Imaging.Color.Blue, 2);

                    double a = 0;
                    double b = 5;
                    double deltaTheta = Math.PI / 4;
                    int segments = 20;

                    for (int i = 0; i < segments; i++)
                    {
                        double theta0 = i * deltaTheta;
                        double theta1 = (i + 1) * deltaTheta;

                        double r0 = a + b * theta0;
                        double r1 = a + b * theta1;

                        double x0 = width / 2 + r0 * Math.Cos(theta0);
                        double y0 = height / 2 + r0 * Math.Sin(theta0);
                        double x3 = width / 2 + r1 * Math.Cos(theta1);
                        double y3 = height / 2 + r1 * Math.Sin(theta1);

                        double thetaC1 = theta0 + deltaTheta / 3;
                        double rC1 = a + b * thetaC1;
                        double x1 = width / 2 + rC1 * Math.Cos(thetaC1);
                        double y1 = height / 2 + rC1 * Math.Sin(thetaC1);

                        double thetaC2 = theta0 + 2 * deltaTheta / 3;
                        double rC2 = a + b * thetaC2;
                        double x2 = width / 2 + rC2 * Math.Cos(thetaC2);
                        double y2 = height / 2 + rC2 * Math.Sin(thetaC2);

                        graphics.DrawBezier(pen, (float)x0, (float)y0, (float)x1, (float)y1, (float)x2, (float)y2, (float)x3, (float)y3);
                    }

                    image.Save();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a procedural spiral pattern for a background image or texture in a Windows desktop application.
 * 2. When you want to create a BMP file that visualizes mathematical curves, such as an Archimedean spiral, for educational or scientific reports.
 * 3. When you need to programmatically draw smooth vector-like graphics using Bezier segments without relying on external design tools.
 * 4. When you are building a custom chart or logo that requires precise control over line thickness and color on a raster canvas.
 * 5. When you must export dynamically generated graphics to a BMP format for compatibility with legacy systems or hardware.
 */
