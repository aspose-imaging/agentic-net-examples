using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output\\filled_rectangle.png";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 200, 200))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue))
                {
                    graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(20, 20, 160, 160));
                }

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 5);
                graphics.DrawRectangle(pen, new Aspose.Imaging.Rectangle(20, 20, 160, 160));

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
 * 1. When a developer needs to generate a PNG badge with a solid blue background and a thick black border for a web dashboard, this code creates the image using Aspose.Imaging, SolidBrush and Pen.
 * 2. When creating a placeholder image for a UI component that requires a filled rectangle with a specific color and outline thickness, the example shows how to draw and save a 200×200 PNG using C# and Aspose.Imaging.
 * 3. When producing a printable label in C# where the main area is a blue rectangle highlighted by a bold black frame, the code demonstrates filling and outlining the shape with SolidBrush and Pen.
 * 4. When automating the creation of a simple thumbnail that visually separates content sections using a colored rectangle with a contrasting border, this snippet uses Aspose.Imaging.Graphics to draw and save the PNG.
 * 5. When writing documentation or tutorials that need a clear example of basic drawing primitives such as FillRectangle and DrawRectangle with SolidBrush and Pen, the code provides a ready‑to‑run C# solution.
 */