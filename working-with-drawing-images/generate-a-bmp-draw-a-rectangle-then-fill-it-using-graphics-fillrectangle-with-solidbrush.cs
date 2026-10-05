// HOW-TO: Create BMP Image with Red Filled Rectangle and Blue Border in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(50, 50, 100, 100);
                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 3);
                graphics.DrawRectangle(pen, rect);

                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    graphics.FillRectangle(brush, rect);
                }

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
 * 1. When you need to generate a simple BMP thumbnail that highlights a region with a colored rectangle for a reporting dashboard.
 * 2. When you want to programmatically add a red‑filled shape with a blue outline to a bitmap used in a Windows Forms custom control.
 * 3. When you are creating test images for computer‑vision algorithms that require a known solid‑color rectangle inside a BMP file.
 * 4. When you need to produce a BMP asset for a game UI where a rectangular button area is drawn and filled at runtime.
 * 5. When you are automating the creation of printable labels and must draw and fill rectangular fields on a BMP canvas.
 */
