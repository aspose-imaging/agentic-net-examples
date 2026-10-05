// HOW-TO: Draw Dashed Ellipse on BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.bmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            BmpOptions createOptions = new BmpOptions();
            createOptions.Source = new FileCreateSource(outputPath, false);
            int width = 400;
            int height = 300;
            using (Image image = Image.Create(createOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightGray);
                Pen pen = new Pen(Color.Blue, 3);
                pen.DashPattern = new float[] { 5, 2 };
                Rectangle rect = new Rectangle(50, 50, 300, 200);
                graphics.DrawEllipse(pen, rect);
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
 * 1. When you need to generate a BMP chart with a highlighted, dashed ellipse to emphasize a region in a reporting dashboard.
 * 2. When creating a custom watermark or overlay for scanned documents where a patterned ellipse marks confidential areas.
 * 3. When producing test images for UI components that require a specific dash pattern on vector shapes for visual consistency.
 * 4. When automating the preparation of graphics for printing where a blue, dashed ellipse outlines a cut‑line on a light‑gray background.
 * 5. When building a game or simulation that programmatically draws dashed elliptical boundaries on bitmap textures at runtime.
 */
