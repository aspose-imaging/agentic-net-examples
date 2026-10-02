// HOW-TO: Draw a Green Square on an Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Color.Green, 3);
                int x = 50;
                int y = 50;
                int size = 100;
                graphics.DrawRectangle(pen, x, y, size, size);
                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to highlight a specific area of a JPEG photo by drawing a green square overlay before saving it as a PNG.
 * 2. When you want to programmatically add a visual marker to images for quality‑control reports in a .NET application.
 * 3. When you are generating annotated screenshots where a green rectangle indicates a region of interest for documentation purposes.
 * 4. When you need to create a simple graphic overlay, such as a green border around a logo, and export the result in lossless PNG format.
 * 5. When you are building an image‑processing pipeline that draws geometric shapes on raster images to prepare them for further analysis or machine‑learning training.
 */
