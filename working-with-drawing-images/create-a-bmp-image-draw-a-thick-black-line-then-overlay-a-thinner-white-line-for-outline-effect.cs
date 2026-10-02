// HOW-TO: Create BMP with Black Line and White Outline in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            string dir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);
            int width = 200;
            int height = 200;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen blackPen = new Pen(Color.Black, 10);
                graphics.DrawLine(blackPen, 20, 20, 180, 180);

                Pen whitePen = new Pen(Color.White, 4);
                graphics.DrawLine(whitePen, 20, 20, 180, 180);

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
 * 1. When you need to generate a BMP diagram that highlights a path with a thick black line and a contrasting white border for better visibility.
 * 2. When creating simple vector‑style graphics for reports, such as a highlighted diagonal line on a white background using Aspose.Imaging in C#.
 * 3. When producing placeholder images for UI testing where a distinct black line with a white outline indicates alignment or spacing.
 * 4. When automating the creation of custom icons that require a bold line and a thin outline to stand out on different backgrounds.
 * 5. When exporting engineering sketches to BMP format and you want the main line emphasized with a contrasting outline for print quality.
 */
