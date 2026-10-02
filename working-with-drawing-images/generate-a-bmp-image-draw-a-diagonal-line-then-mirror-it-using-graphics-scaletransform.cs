// HOW-TO: Create BMP with Diagonal Mirror Using Graphics ScaleTransform in C# (Aspose.Imaging for .NET)
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
            string outputPath = Path.Combine("Output", "output.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawLine(pen, 0, 0, width - 1, height - 1);

                graphics.ScaleTransform(-1, 1);
                graphics.TranslateTransform(-width, 0);
                graphics.DrawLine(pen, 0, 0, width - 1, height - 1);

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
 * 1. When you need to generate a BMP placeholder image that includes a mirrored diagonal line for UI testing or documentation.
 * 2. When you want to programmatically draw a symmetric pattern by drawing a line and reflecting it across the vertical axis in a .NET application.
 * 3. When you need to add a simple mirrored watermark or logo effect to an image without using external graphic design tools.
 * 4. When you are building custom charts or diagrams that require a reflected line for visual emphasis and need to create them on the fly.
 * 5. When you are automating the creation of mirrored sprite assets for a game and want to produce the BMP files directly in C#.
 */
