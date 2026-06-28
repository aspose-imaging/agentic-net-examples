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
            // Output BMP file path
            string outputPath = @"C:\temp\arrow.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen with arrow end cap
                Pen pen = new Pen(Color.Black, 5f);
                pen.EndCap = LineCap.ArrowAnchor;

                // Draw horizontal line with arrow
                graphics.DrawLine(pen, new Point(50, 200), new Point(350, 200));

                // Draw vertical line with arrow
                graphics.DrawLine(pen, new Point(200, 50), new Point(200, 350));

                // Save the image
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
 * 1. When a developer needs to generate a BMP diagram that highlights flow direction by drawing arrows at the ends of lines, such as for a simple network topology illustration.
 * 2. When creating printable engineering schematics in C# where straight lines must indicate vector direction using a Pen with a custom ArrowAnchor end cap in an Aspose.Imaging BMP image.
 * 3. When building an automated report that embeds 400×400 pixel BMP charts with directional arrows to show process steps, requiring the use of Graphics.DrawLine and LineCap.ArrowAnchor.
 * 4. When a desktop application must programmatically add annotated arrows to a white background BMP file for user‑guided tutorials, leveraging Aspose.Imaging’s Pen and Graphics classes.
 * 5. When exporting GIS route segments to a BMP file and needing arrowheads on each segment to convey travel direction, using C# and Aspose.Imaging’s custom end cap functionality.
 */