// HOW-TO: Check If GraphicsPath Locks Source JPEG After Drawing In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                RectangleShape rectShape = new RectangleShape(new RectangleF(10, 10, 100, 50));
                figure.AddShape(rectShape);
                path.AddFigure(figure);

                graphics.DrawPath(new Pen(Color.Blue, 2), path);

                image.Save(outputPath, new PngOptions());
            }

            try
            {
                File.Delete(inputPath);
                Console.WriteLine("Input file deleted successfully; GraphicsPath does not retain a reference to the source image.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to delete input file: {ex.Message}");
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
 * 1. When you need to draw vector shapes on an existing JPEG and then release the original file for further processing or deletion.
 * 2. When you want to convert a JPEG to PNG after adding annotations without keeping the source file open.
 * 3. When you must ensure that Aspose.Imaging’s GraphicsPath does not keep a file handle, allowing safe cleanup in batch image pipelines.
 * 4. When you are building a server‑side service that overlays graphics on uploaded images and must delete the uploads immediately to free storage.
 * 5. When you are testing memory and file‑handle behavior of drawing operations to prevent file‑locking issues in long‑running C# applications.
 */
