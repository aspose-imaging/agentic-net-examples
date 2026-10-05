// HOW-TO: Crop Center 400x400 From PNG and Save As SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputPath = "input.png";
        string outputPath = "output/output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                int targetSize = 400;
                int left = (raster.Width - targetSize) / 2;
                int right = left;
                int top = (raster.Height - targetSize) / 2;
                int bottom = top;

                raster.Crop(left, right, top, bottom);

                SvgOptions svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
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
 * 1. When you need to extract a fixed‑size thumbnail from a large PNG and deliver it as a scalable SVG for responsive web graphics.
 * 2. When converting raster logos stored as PNG into vector SVGs after cropping the central area to fit branding guidelines.
 * 3. When generating cut‑out icons from user‑uploaded PNG files for use in high‑resolution UI designs that require SVG format.
 * 4. When preprocessing PNG assets by cropping a 400‑pixel square before converting them to SVG for inclusion in printable PDFs.
 * 5. When automating a batch process that trims the center of PNG screenshots and saves them as SVGs for lightweight documentation.
 */
