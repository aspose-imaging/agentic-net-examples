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
            string outputPath = @"C:\temp\output.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);
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
 * 1. When creating a multi‑layer PNG thumbnail in C# with Aspose.Imaging and you need to limit drawing to a specific rectangle for one layer, calling Graphics.ResetClip afterward restores the full canvas for the next layer.
 * 2. When generating a PDF preview image where text is clipped to a column width, using Graphics.ResetClip after rendering the column ensures subsequent graphics like watermarks are drawn across the entire page.
 * 3. When applying a circular mask to a portrait photo and then adding a border around the whole image, resetting the clipping region with Graphics.ResetClip prevents the border from being confined to the circle.
 * 4. When compositing several icons onto a single 500 × 500 PNG sprite sheet and each icon is drawn within its own clipped region, Graphics.ResetClip is required after each icon to avoid bleed‑through into neighboring icons.
 * 5. When programmatically stamping a QR code onto a product label image and the QR code is drawn inside a predefined area, calling Graphics.ResetClip after the stamp allows later operations such as adding a full‑width footer text.
 */