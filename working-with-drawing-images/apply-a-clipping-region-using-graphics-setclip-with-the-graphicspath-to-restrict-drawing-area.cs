// HOW-TO: How To Clip Drawing Area With GraphicsPath In Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"c:\temp\input.png";
            string outputPath = @"c:\temp\clipped_output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define clipping region as a rectangle
                GraphicsPath clipPath = new GraphicsPath();
                Figure clipFigure = new Figure();
                clipFigure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 200f, 200f)));
                clipPath.AddFigure(clipFigure);
                graphics.Clip = new Region(clipPath);

                // Draw a diagonal line (only the part inside the clip will appear)
                Pen redPen = new Pen(Color.Red, 5);
                graphics.DrawLine(redPen, new Point(0, 0), new Point(image.Width, image.Height));

                // Draw a rectangle that extends beyond the clip region
                Pen bluePen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(bluePen, new Rectangle(50, 50, 300, 300));

                // Save the result
                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to restrict drawing to a specific rectangular region of a PNG image, such as creating a masked overlay in a C# application.
 * 2. When you want to generate a thumbnail that only shows content inside a defined area while discarding the rest of the original image.
 * 3. When you are building a reporting tool that draws charts but must hide parts that fall outside a printable margin using Aspose.Imaging.
 * 4. When you need to apply a custom clipping mask before compositing multiple shapes onto an image to avoid unwanted overlap.
 * 5. When you are preparing images for UI components and must ensure that drawn lines or shapes do not exceed a designated viewport.
 */
