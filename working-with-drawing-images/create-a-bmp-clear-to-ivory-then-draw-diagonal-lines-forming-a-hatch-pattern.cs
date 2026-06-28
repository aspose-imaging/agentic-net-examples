using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = source
            };

            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 500, 500))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.Ivory);

                Pen pen = new Pen(Aspose.Imaging.Color.Black, 1);
                graphics.DrawRectangle(pen, new Rectangle(0, 0, canvas.Width, canvas.Height));

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
 * 1. When a developer needs to generate a 500 × 500 BMP file with a solid ivory background for use as a placeholder image in a Windows desktop application.
 * 2. When an automated reporting tool must create a bitmap chart legend that requires a clean ivory canvas and a black rectangular border drawn with Aspose.Imaging in C#.
 * 3. When a batch image processing script has to produce BMP thumbnails with a consistent background color and a simple frame for branding purposes.
 * 4. When a game asset pipeline needs to programmatically generate texture maps in BMP format with a uniform ivory fill and a defined border before applying further effects.
 * 5. When a document generation system creates printable forms and needs to embed a blank BMP page with an ivory background and a black outline as a template for manual annotations.
 */