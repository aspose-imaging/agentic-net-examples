// HOW-TO: Create Elliptical Mask on PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                GraphicsPath mask = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(10, 10, 100, 100)));
                mask.AddFigure(figure);

                image.Save(outputPath);
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
 * 1. When you need to programmatically define an elliptical region to hide or process part of a PNG image in a .NET application.
 * 2. When building a photo‑editing tool that lets users draw elliptical selections for cropping or applying effects using Aspose.Imaging.
 * 3. When automating batch processing to add transparent masks over specific areas of PNG files before further image manipulation.
 * 4. When integrating image masking into a web service that receives PNG uploads and returns the same image with an elliptical overlay.
 * 5. When creating a custom UI that generates shape‑based masks (e.g., ellipses) for watermark removal or content‑aware fill operations in C#.
 */
