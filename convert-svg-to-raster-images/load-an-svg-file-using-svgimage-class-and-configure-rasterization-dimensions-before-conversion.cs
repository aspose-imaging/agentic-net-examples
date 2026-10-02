// HOW-TO: Convert SVG to PNG with Custom Width and Height in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "example.svg");
        string outputPath = Path.Combine("Output", "example.png");

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = 800,
                    PageHeight = 600,
                    BackgroundColor = Color.White
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate thumbnail PNG images from scalable SVG logos at a fixed 800×600 size for a web gallery.
 * 2. When you must embed SVG icons into a PDF report that only supports raster images, requiring conversion to PNG with a white background.
 * 3. When an e‑commerce platform stores product illustrations as SVG and you need to create high‑resolution PNG previews for email newsletters.
 * 4. When a mobile app consumes PNG assets and you need to pre‑render SVG artwork at specific dimensions during the build process.
 * 5. When automating batch processing of SVG diagrams to PNG files with consistent sizing for documentation or training materials.
 */
