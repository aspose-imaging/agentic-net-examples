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
            string outputPath = @"C:\temp\outline.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(stream);

                int width = 400;
                int height = 300;

                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);

                    int x1 = 50, y1 = 50, x2 = 350, y2 = 250;

                    Pen blackPen = new Pen(Color.Black, 10);
                    graphics.DrawLine(blackPen, new Point(x1, y1), new Point(x2, y2));

                    Pen whitePen = new Pen(Color.White, 4);
                    graphics.DrawLine(whitePen, new Point(x1, y1), new Point(x2, y2));

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
 * 1. When a developer needs to programmatically create a BMP image and draw a thick black line with a thin white outline using Aspose.Imaging’s Image.Create and Graphics classes for a simple diagram in a Windows desktop app.
 * 2. When generating printable schematics where a 10‑pixel black line outlined by a 4‑pixel white stroke improves contrast on monochrome printers, leveraging C# Pen objects and BMP output.
 * 3. When producing thumbnail previews that highlight edges by drawing an outlined line on a bitmap using Aspose.Imaging for .NET, C# streams, and the Graphics.DrawLine method.
 * 4. When adding a decorative border to a bitmap in a batch‑processing script that writes the BMP file via FileStream, BmpOptions, and draws the outline with black and white Pen objects.
 * 5. When building a custom UI control that requires dynamic drawing of outlined lines on a BMP canvas for visual feedback, using Aspose.Imaging’s Graphics, Pen, and Image.Save operations.
 */