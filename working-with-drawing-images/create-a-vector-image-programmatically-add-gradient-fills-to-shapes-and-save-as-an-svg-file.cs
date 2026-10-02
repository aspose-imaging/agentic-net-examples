// HOW-TO: Create SVG With Linear Gradient Fill Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.svg";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            SvgOptions svgOptions = new SvgOptions();
            int width = 800;
            int height = 600;

            using (Image image = Image.Create(svgOptions, width, height))
            {
                Graphics graphics = new Graphics(image);

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(width, height),
                    Color.Red,
                    Color.Blue))
                {
                    graphics.FillRectangle(brush, new Rectangle(0, 0, width, height));
                }

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
 * 1. When you need to generate a scalable vector graphic with a smooth color transition for a web banner programmatically in C#.
 * 2. When you want to create dynamic SVG icons that adapt their colors based on user data using Aspose.Imaging.
 * 3. When you are building a reporting tool that exports charts as SVG files with gradient backgrounds for high‑resolution printing.
 * 4. When you need to automate the production of vector illustrations with custom gradients for a marketing campaign without using a design editor.
 * 5. When you are developing a cross‑platform UI that requires on‑the‑fly SVG assets with gradient fills for responsive layouts.
 */
