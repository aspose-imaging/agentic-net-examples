// HOW-TO: Create BMP with Thick Red Line and Thin Black Outline in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";
            string dir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(dir))
                dir = ".";
            Directory.CreateDirectory(dir);

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen redPen = new Pen(Color.Red, 10);
                graphics.DrawLine(redPen, new Point(20, 20), new Point(180, 180));

                Pen blackPen = new Pen(Color.Black, 2);
                graphics.DrawLine(blackPen, new Point(20, 20), new Point(180, 180));

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
 * 1. When you need to generate a BMP diagram that highlights a path with a bold red line and a subtle black border for better visibility in a .NET reporting tool.
 * 2. When creating custom icons or UI assets where a thick colored stroke must be emphasized with a thin contrasting outline using Aspose.Imaging in C#.
 * 3. When producing test images for computer‑vision algorithms that require a clear red line edge highlighted by a black line to evaluate edge detection accuracy.
 * 4. When automating the preparation of printable schematics that need a prominent red guide line with a black accent to ensure clarity on monochrome printers.
 * 5. When building a game map editor that programmatically draws highlighted routes on a BMP background, using a thick red line topped with a thin black line for contrast.
 */
