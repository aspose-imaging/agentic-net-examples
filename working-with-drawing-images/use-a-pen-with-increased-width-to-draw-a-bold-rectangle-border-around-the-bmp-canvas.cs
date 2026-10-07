// HOW-TO: Create BMP Image With Bold Rectangle Border Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        string outputPath = "output/bold_rectangle.bmp";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen pen = new Pen(Aspose.Imaging.Color.Black, 5);
                graphics.DrawRectangle(pen, 0, 0, width - 1, height - 1);

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
 * 1. When you need to generate a plain BMP file with a thick black frame for a printable label or template.
 * 2. When an application must programmatically add a visible border to dynamically created bitmap images for UI thumbnails.
 * 3. When you are preparing test images with a defined rectangular outline to validate image processing algorithms.
 * 4. When a reporting tool requires a BMP chart background surrounded by a bold rectangle for emphasis.
 * 5. When you want to create a simple placeholder image with a clear border to indicate image dimensions in a content management system.
 */
