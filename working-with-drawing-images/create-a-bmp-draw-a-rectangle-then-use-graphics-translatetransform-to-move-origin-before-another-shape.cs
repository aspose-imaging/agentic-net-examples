// HOW-TO: Create BMP With Translated Rectangle Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            int width = 200;
            int height = 200;
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);
                Pen pen1 = new Pen(Aspose.Imaging.Color.Blue, 3);
                graphics.DrawRectangle(pen1, new Rectangle(20, 20, 100, 50));
                graphics.TranslateTransform(30, 40);
                Pen pen2 = new Pen(Aspose.Imaging.Color.Red, 3);
                graphics.DrawRectangle(pen2, new Rectangle(20, 20, 100, 50));
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
 * 1. When you need to generate a BMP file with multiple shapes positioned relative to a shifted coordinate system for custom UI icons.
 * 2. When you want to programmatically draw a rectangle and then offset subsequent drawings without recalculating coordinates in a C# imaging application.
 * 3. When creating a template image where the second shape must be placed at a specific offset from the first, using Aspose.Imaging’s TranslateTransform.
 * 4. When automating the production of simple graphics for reports or dashboards that require precise placement of elements in a bitmap.
 * 5. When building a graphics editor that demonstrates coordinate transformation by rendering shapes before and after applying a translation on a BMP canvas.
 */
