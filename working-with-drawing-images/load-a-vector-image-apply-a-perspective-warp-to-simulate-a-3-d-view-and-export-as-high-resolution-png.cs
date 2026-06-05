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
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (Image vectorImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = vectorImage.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (var ms = new MemoryStream())
                {
                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                    {
                        rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a web application needs to generate high‑resolution PNG thumbnails from user‑uploaded SVG logos using Aspose.Imaging in C#.
 * 2. When an e‑learning platform programmatically converts scalable vector diagrams (SVG) into PNG images for inclusion in PDF course materials.
 * 3. When a desktop publishing tool rasterizes SVG icons into PNG sprites for a Windows Forms UI by loading the vector file and saving it as PNG.
 * 4. When a reporting service transforms SVG chart files into PNG images to embed in email reports that require a fixed raster format.
 * 5. When a CI/CD pipeline validates SVG assets by converting them to PNG and verifying the output dimensions and quality with Aspose.Imaging for .NET.
 */