// HOW-TO: Draw an Off‑Center Oval on a PNG Canvas Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/oval.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int canvasWidth = 400;
            int canvasHeight = 300;
            var pngOptions = new PngOptions();

            using (Image image = Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 5);
                // Off‑center oval parameters
                int x = 100; // X coordinate of the top‑left corner
                int y = 50;  // Y coordinate of the top‑left corner
                int width = 200;
                int height = 150;

                graphics.DrawEllipse(pen, x, y, width, height);

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
 * 1. When you need to generate a PNG badge with a decorative off‑center oval using Aspose.Imaging for .NET.
 * 2. When creating dynamic charts in a web service and you want to highlight a data region by drawing an off‑center oval on a PNG canvas.
 * 3. When producing printable certificates and you must add an off‑center oval frame to the image with Aspose.Imaging.
 * 4. When building a game UI and you require an off‑center oval button background rendered to a PNG asset at runtime.
 * 5. When automating custom thumbnail creation that includes an offset oval overlay to indicate the focus area.
 */
