// HOW-TO: Convert PNG to SVG with Blue Border Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.png");
            string outputPath = Path.Combine("Output", "result.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage pngImage = (RasterImage)Image.Load(inputPath))
            {
                int width = pngImage.Width;
                int height = pngImage.Height;

                using (SvgOptions createOptions = new SvgOptions())
                {
                    using (Image svgImage = Image.Create(createOptions, width, height))
                    {
                        Graphics graphics = new Graphics(svgImage);

                        graphics.DrawImage(pngImage, new Point(0, 0));

                        Pen bluePen = new Pen(Aspose.Imaging.Color.Blue);
                        graphics.DrawRectangle(bluePen, new Rectangle(0, 0, width - 1, height - 1));

                        using (SvgOptions saveOptions = new SvgOptions())
                        {
                            svgImage.Save(outputPath, saveOptions);
                        }
                    }
                }
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
 * 1. When you need to embed a raster PNG into a scalable SVG for responsive web design while adding a blue outline.
 * 2. When generating vector assets from existing PNG logos and highlighting them with a colored stroke for branding purposes.
 * 3. When converting product images to SVG format for print workflows and requiring a consistent blue border around each image.
 * 4. When creating diagram overlays where a PNG background must be vectorized and framed with a specific color using C#.
 * 5. When automating batch processing of PNG files to SVG with a custom border for UI icons in a .NET application.
 */
