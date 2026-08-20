// HOW-TO: Resize BMP to Half Size and Convert to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                image.Resize(newWidth, newHeight, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                var svgOptions = new SvgOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = new Aspose.Imaging.SizeF(newWidth, newHeight)
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a scalable SVG thumbnail from a large BMP logo for responsive web design.
 * 2. When an application must reduce the file size of legacy BMP assets by half before embedding them in vector‑based reports.
 * 3. When converting scanned BMP diagrams into SVG format to enable zoom‑in without pixelation in a C# desktop tool.
 * 4. When automating batch processing to create half‑size SVG icons from BMP resources for mobile app UI.
 * 5. When integrating Aspose.Imaging in a .NET service that transforms high‑resolution BMP images into lightweight SVG files for faster loading.
 */
