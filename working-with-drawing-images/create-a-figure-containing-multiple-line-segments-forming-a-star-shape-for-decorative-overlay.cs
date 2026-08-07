using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"c:\temp\star.png";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                PointF[] starPoints = new PointF[]
                {
                    new PointF(250f, 50f),
                    new PointF(300f, 200f),
                    new PointF(450f, 200f),
                    new PointF(325f, 300f),
                    new PointF(375f, 450f),
                    new PointF(250f, 350f),
                    new PointF(125f, 450f),
                    new PointF(175f, 300f),
                    new PointF(50f, 200f),
                    new PointF(200f, 200f)
                };

                Pen pen = new Pen(Color.Blue, 2);
                for (int i = 0; i < starPoints.Length; i++)
                {
                    PointF start = starPoints[i];
                    PointF end = starPoints[(i + 1) % starPoints.Length];
                    graphics.DrawLine(pen, start, end);
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

/*
 * Real-World Use Cases:
 * 1. When a developer wants to generate a PNG watermark with a custom star‑shaped overlay for branding an image in a .NET web application.
 * 2. When a developer needs to programmatically create a 500 × 500 pixel canvas and draw vector line segments to produce a decorative star icon for a UI button using Aspose.Imaging.
 * 3. When a developer must export a star‑shaped diagram as a high‑resolution PNG file for inclusion in a PDF report generated from C# code.
 * 4. When a developer is building a game asset pipeline that requires drawing simple geometric shapes, such as a star, directly into image files without using external design tools.
 * 5. When a developer wants to automate the creation of a printable star‑shaped badge by drawing lines with a Pen object and saving the result as a PNG using Aspose.Imaging’s Image and Graphics classes.
 */