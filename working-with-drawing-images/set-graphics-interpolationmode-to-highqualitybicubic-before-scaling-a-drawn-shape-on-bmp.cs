// HOW-TO: Scale a BMP Shape With High Quality Bicubic Interpolation In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions createOptions = new BmpOptions();
            createOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(createOptions, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.ScaleTransform(2.0f, 2.0f);

                Pen pen = new Pen(Color.Blue, 2);
                Rectangle rect = new Rectangle(10, 10, 50, 50);
                graphics.DrawRectangle(pen, rect);

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
 * 1. When you need to generate a high-resolution BMP thumbnail of a vector shape while preserving smooth edges.
 * 2. When creating a printable bitmap where a rectangle must be enlarged without pixelation using Aspose.Imaging.
 * 3. When developing a C# utility that programmatically draws and scales graphics on BMP files for reports or dashboards.
 * 4. When converting diagram elements to a BMP image and require bicubic interpolation to maintain visual quality after scaling.
 * 5. When building an automated image-processing pipeline that draws shapes on BMP canvases and needs consistent high-quality scaling across different devices.
 */
