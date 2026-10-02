// HOW-TO: Create BMP Image with Thick Border and Inset Fill in C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.bmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);
            int width = 400;
            int height = 300;
            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                Pen borderPen = new Pen(Color.Black, 10);
                graphics.DrawRectangle(borderPen, 0, 0, width, height);
                int inset = 20;
                using (SolidBrush innerBrush = new SolidBrush(Color.LightGray))
                {
                    graphics.FillRectangle(innerBrush, inset, inset, width - 2 * inset, height - 2 * inset);
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
 * 1. When you need to generate a BMP placeholder image with a visible frame for a PDF report or documentation preview.
 * 2. When creating custom UI icons or buttons that require a solid background surrounded by a thick black border in a Windows desktop application.
 * 3. When producing test images for image‑processing algorithms that must contain a known rectangular region and border for validation.
 * 4. When automating the creation of printable forms where the outer margin is highlighted by a thick border and the inner area is pre‑filled with a light‑gray background.
 * 5. When building a batch process that adds a uniform border and background to scanned images before they are stored in a BMP archive.
 */
