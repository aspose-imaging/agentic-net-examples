// HOW-TO: Create BMP and Draw Rotated Rectangle with Graphics in C# (Aspose.Imaging for .NET)
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
            string outputPath = "Output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 3);
                Rectangle rect1 = new Rectangle(20, 20, 100, 80);
                graphics.DrawRectangle(pen, rect1);

                graphics.RotateTransform(45);

                Rectangle rect2 = new Rectangle(20, 20, 100, 80);
                graphics.DrawRectangle(pen, rect2);

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
 * 1. When you need to generate a BMP file with a rotated shape for a custom UI icon in a C# desktop application.
 * 2. When you want to programmatically create a diagram that shows before‑and‑after rotation of a rectangle for documentation or tutorials.
 * 3. When you are building a report that requires overlaying rotated graphics on a bitmap background using Aspose.Imaging.
 * 4. When you need to produce test images with known rotation angles to validate image‑processing algorithms.
 * 5. When you are automating the creation of simple game assets, such as rotated tiles, directly from C# code.
 */
