// HOW-TO: Create SVG From PNG With 2-Pixel Stroke Border In C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "input.png");
            string outputPath = Path.Combine("Output", "output.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image pngImage = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)pngImage;
                if (!raster.IsCached) raster.CacheData();

                using (SvgOptions svgOptions = new SvgOptions())
                {
                    svgOptions.Source = new FileCreateSource(outputPath, false);
                    using (Image svgImage = Image.Create(svgOptions, raster.Width, raster.Height))
                    {
                        Graphics graphics = new Graphics(svgImage);
                        graphics.Clear(Color.White);

                        Pen pen = new Pen(Color.Black);
                        pen.Width = 2;

                        graphics.DrawImage(raster, new Point(0, 0));
                        graphics.DrawRectangle(pen, new Rectangle(0, 0, raster.Width, raster.Height));

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
 * 1. When you need to embed a raster PNG into a scalable SVG for responsive web graphics while adding a visible border.
 * 2. When converting legacy PNG assets to SVG format to reduce file size and enable infinite scaling in a C# application.
 * 3. When generating vector outlines around bitmap images for printing or PDF export where a consistent 2-pixel stroke is required.
 * 4. When automating batch processing of PNG logos into SVG files with a uniform border for branding guidelines.
 * 5. When creating SVG placeholders that display a PNG thumbnail with a black frame for UI mockups in .NET projects.
 */
