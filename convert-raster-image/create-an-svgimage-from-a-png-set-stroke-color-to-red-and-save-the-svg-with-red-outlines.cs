// HOW-TO: Create SVG From PNG With Red Outline Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string inputPath = "Input\\image.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "Output\\image.svg";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                int width = raster.Width;
                int height = raster.Height;

                SvgGraphics2D svgGraphics = new SvgGraphics2D(width, height, 96);
                svgGraphics.DrawImage(raster, new Point(0, 0));
                svgGraphics.DrawRectangle(new Pen(Color.Red), 0, 0, width, height);

                using (SvgImage svgImage = svgGraphics.EndRecording())
                {
                    svgImage.Save(outputPath);
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
 * 1. When you need to embed a raster PNG into an SVG for web graphics while adding a red border to highlight the image.
 * 2. When generating scalable vector assets from existing PNG logos and want a colored stroke that matches brand guidelines.
 * 3. When converting PNG screenshots to printable SVG diagrams and require a visible red outline for emphasis.
 * 4. When transforming PNG icons into responsive SVG UI elements and need to programmatically add a red border for a selected state.
 * 5. When automating batch conversion of PNG files to SVG with consistent red outlines for use in documentation or presentations.
 */
