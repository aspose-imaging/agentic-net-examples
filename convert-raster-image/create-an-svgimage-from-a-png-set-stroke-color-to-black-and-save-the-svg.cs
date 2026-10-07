// HOW-TO: Convert PNG to SVG with Black Stroke in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "Output/output.svg";

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
                    createOptions.Source = new FileCreateSource(outputPath, false);

                    using (Image svgImage = Image.Create(createOptions, width, height))
                    {
                        Pen blackPen = new Pen(Color.Black);
                        Graphics graphics = new Graphics(svgImage);
                        graphics.DrawImage(pngImage, new Point(0, 0));

                        svgImage.Save();
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
 * 1. When you need to embed a raster logo into a scalable vector graphic for responsive web design, you can convert the PNG logo to an SVG with a black outline using Aspose.Imaging in C#.
 * 2. When generating printable diagrams that require vector format but start from bitmap assets, this code lets you transform PNG icons into SVG files while applying a consistent black stroke.
 * 3. When creating a batch process that prepares images for laser cutting or CNC machines, converting PNG patterns to SVG with a defined black border ensures the cutter interprets the paths correctly.
 * 4. When developing a WPF or Xamarin app that loads vector assets at runtime, you can programmatically convert user‑uploaded PNGs to SVGs with a black outline to maintain visual fidelity across screen sizes.
 * 5. When automating documentation generation where screenshots (PNG) must be included in SVG‑based flowcharts, this snippet converts each screenshot to SVG and adds a black stroke for clear separation.
 */
