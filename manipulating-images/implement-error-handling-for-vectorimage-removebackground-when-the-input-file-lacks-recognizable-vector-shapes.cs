// HOW-TO: Remove Background from SVG and Save as Transparent PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var vectorImage = image as VectorImage;
                if (vectorImage == null)
                {
                    Console.Error.WriteLine("The file does not contain a vector image.");
                    return;
                }

                try
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"RemoveBackground failed: {ex.Message}");
                    return;
                }

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = image.Size
                    }
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
 * 1. When you need to automatically erase the background of an SVG file and export it as a transparent PNG for web graphics.
 * 2. When your application must verify that an input file is a vector image before processing to avoid runtime errors.
 * 3. When you want to handle cases where an SVG contains no recognizable shapes and gracefully report the failure.
 * 4. When you need to rasterize vector artwork to a PNG with an alpha channel while preserving the original dimensions.
 * 5. When you are building a batch conversion tool that creates PNG assets from SVGs and must log missing files or processing exceptions.
 */
