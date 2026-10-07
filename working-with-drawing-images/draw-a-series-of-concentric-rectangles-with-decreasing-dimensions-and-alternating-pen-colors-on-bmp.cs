// HOW-TO: Create Concentric Colored Rectangles on BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 500;
            int height = 500;
            int rectangleCount = 10;
            int marginStep = 20;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                for (int i = 0; i < rectangleCount; i++)
                {
                    int margin = i * marginStep;
                    int rectWidth = width - 2 * margin;
                    int rectHeight = height - 2 * margin;
                    if (rectWidth <= 0 || rectHeight <= 0)
                        break;

                    Rectangle rect = new Rectangle(margin, margin, rectWidth, rectHeight);
                    Color penColor = (i % 2 == 0) ? Color.Red : Color.Blue;
                    Pen pen = new Pen(penColor, 3);
                    graphics.DrawRectangle(pen, rect);
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
 * 1. When you need to generate a BMP diagram with nested frames for a technical manual, this code programmatically draws concentric rectangles with alternating colors.
 * 2. When creating test images to verify image‑processing pipelines, you can use the sample to produce predictable BMP files containing multiple bordered shapes.
 * 3. When building a custom UI component that displays layered borders, the code shows how to render the layers directly onto a bitmap using Aspose.Imaging.
 * 4. When automating the production of printable assets such as certificates or badges that require a decorative border pattern, the script creates the required BMP background.
 * 5. When teaching image‑drawing concepts in C#, the example demonstrates how to use Graphics, Pen, and Rectangle objects to draw repeated shapes on a bitmap file.
 */
