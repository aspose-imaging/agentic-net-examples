// HOW-TO: Create BMP Canvas Draw Diagonal Line And Reflect Vertically In C# (Aspose.Imaging for .NET)
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            Source source = new FileCreateSource(outputPath, false);
            bmpOptions.Source = source;

            int width = 200;
            int height = 200;

            using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);
                graphics.DrawLine(pen, 0, 0, width - 1, height - 1);

                // Reflect across vertical axis
                graphics.TranslateTransform(width, 0);
                graphics.ScaleTransform(-1, 1);
                graphics.DrawLine(pen, 0, 0, width - 1, height - 1);

                canvas.Save();
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
 * 1. When you need to generate a BMP file with a simple geometric pattern for testing image rendering pipelines.
 * 2. When you want to programmatically create a mirrored diagonal line to illustrate symmetry in educational graphics.
 * 3. When building a custom watermark that requires a reflected line across the vertical axis in a bitmap.
 * 4. When preparing sample assets for a UI component that demonstrates transformation functions like TranslateTransform and ScaleTransform.
 * 5. When automating the creation of diagnostic images to verify that graphics transformations are applied correctly in a .NET application.
 */
