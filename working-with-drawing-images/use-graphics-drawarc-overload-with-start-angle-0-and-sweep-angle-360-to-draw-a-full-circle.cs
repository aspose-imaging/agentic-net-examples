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
            string outputPath = @"C:\temp\circle.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    Pen pen = new Pen(Color.Black, 2);
                    Rectangle rect = new Rectangle(50, 50, 400, 400);
                    graphics.DrawArc(pen, rect, 0, 360);

                    image.Save();
                }
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
 * 1. A developer can use this code to generate a 500 × 500 PNG badge with a black circular border around a user’s profile picture by drawing a full circle with Aspose.Imaging’s Graphics.DrawArc.
 * 2. When building a reporting tool that exports charts as PNG files, a developer can draw a complete circle to serve as a background for a radial progress indicator using the Pen and Rectangle parameters.
 * 3. An e‑learning platform can programmatically create lesson slide assets by rendering a perfect circle in a PNG image, leveraging C# and Aspose.Imaging’s DrawArc overload for consistent diagram elements.
 * 4. To provide a status‑icon library for a monitoring dashboard, a developer can produce transparent PNG icons that contain a full circle drawn with Graphics.DrawArc, ensuring uniform sizing and line thickness.
 * 5. In a game‑asset pipeline, a developer may need to generate circular collision‑mask sprites as PNG files, using the DrawArc method with a 0‑degree start angle and 360‑degree sweep to guarantee a precise circle shape.
 */