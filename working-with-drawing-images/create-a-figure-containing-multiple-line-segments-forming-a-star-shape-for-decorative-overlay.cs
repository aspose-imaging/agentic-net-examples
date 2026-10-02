// HOW-TO: Create a Red Star Shape PNG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/star.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions options = new PngOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            using (Aspose.Imaging.Image canvas = Aspose.Imaging.Image.Create(options, width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.White);

                float cx = width / 2f;
                float cy = height / 2f;
                float outer = 200f;
                float inner = 80f;

                List<Aspose.Imaging.PointF> points = new List<Aspose.Imaging.PointF>();
                for (int i = 0; i < 10; i++)
                {
                    double angle = Math.PI / 5 * i - Math.PI / 2;
                    float r = (i % 2 == 0) ? outer : inner;
                    points.Add(new Aspose.Imaging.PointF(
                        cx + (float)(r * Math.Cos(angle)),
                        cy + (float)(r * Math.Sin(angle))
                    ));
                }

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 3);

                Aspose.Imaging.PointF[] linePoints = new Aspose.Imaging.PointF[points.Count + 1];
                for (int i = 0; i < points.Count; i++)
                {
                    linePoints[i] = points[i];
                }
                linePoints[points.Count] = points[0]; // close the star

                graphics.DrawLines(pen, linePoints);

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
 * 1. When you need to generate a decorative star overlay on a PNG image for a web banner using Aspose.Imaging in a C# application.
 * 2. When you want to programmatically draw custom vector shapes such as a star for a game UI asset pipeline in .NET.
 * 3. When you must create a high‑resolution PNG logo that includes a red star outline without using external design tools.
 * 4. When you are building an automated report generator that adds a star‑shaped watermark to each page image via C# code.
 * 5. When you require a repeatable script to produce star‑shaped icons for mobile apps, saving them directly as PNG files.
 */
