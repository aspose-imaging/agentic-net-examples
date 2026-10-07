// HOW-TO: Create BMP With Filled Red Ellipse And Black Outline In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath);

            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Rectangle ellipseRect = new Aspose.Imaging.Rectangle(20, 20, 160, 160);

                using (SolidBrush fillBrush = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    graphics.FillEllipse(fillBrush, ellipseRect);
                }

                Pen outlinePen = new Pen(Aspose.Imaging.Color.Black, 3);
                graphics.DrawEllipse(outlinePen, ellipseRect);

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
 * 1. Use this code to generate a BMP icon containing a red filled ellipse with a black border for UI elements or placeholders.
 * 2. Use it when you must supply legacy software with a bitmap image that includes a simple shape without using external design tools.
 * 3. Use it to programmatically add a red circular badge with a black outline to a report or PDF that embeds BMP graphics.
 * 4. Use it to create a known‑pattern BMP image for testing image‑processing or computer‑vision algorithms that detect ellipses.
 * 5. Use it to dynamically generate sprite graphics for a game or simulation where a BMP ellipse is needed at runtime.
 */
