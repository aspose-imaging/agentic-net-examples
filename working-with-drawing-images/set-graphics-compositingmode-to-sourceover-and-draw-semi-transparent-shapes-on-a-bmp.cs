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
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                using (SolidBrush redBrush = new SolidBrush(Color.Red))
                {
                    redBrush.Opacity = 0.5f;
                    graphics.FillRectangle(redBrush, new Rectangle(50, 50, 200, 150));
                }
                graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(50, 50, 200, 150));

                using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
                {
                    blueBrush.Opacity = 0.5f;
                    graphics.FillEllipse(blueBrush, new Rectangle(150, 100, 200, 150));
                }
                graphics.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(150, 100, 200, 150));

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
 * 1. When a developer needs to generate a BMP report thumbnail that overlays semi‑transparent warning icons on a white background using Aspose.Imaging’s Graphics with SourceOver compositing.
 * 2. When creating custom watermarks for scanned documents where a translucent red rectangle and blue ellipse must be drawn onto a BMP file in a C# application.
 * 3. When building a UI mock‑up tool that programmatically draws overlapping shapes with adjustable opacity on a BMP canvas for previewing design concepts.
 * 4. When automating the production of badge images that combine semi‑transparent colored shapes and outlines in a BMP format for use in legacy Windows applications.
 * 5. When implementing a batch process that adds semi‑transparent highlight regions to BMP screenshots to indicate areas of interest before archiving them.
 */