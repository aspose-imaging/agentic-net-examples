// HOW-TO: Apply Gaussian Blur, Crop Center, and Save PNG as SVG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, blurOptions);

                int cropWidth = raster.Width / 2;
                int cropHeight = raster.Height / 2;
                int x = (raster.Width - cropWidth) / 2;
                int y = (raster.Height - cropHeight) / 2;
                var cropRect = new Rectangle(x, y, cropWidth, cropHeight);
                raster.Crop(cropRect);

                raster.Save(outputPath, new SvgOptions());
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
 * 1. When you need to soften a photograph and export the central portion as a scalable vector for web graphics.
 * 2. When creating thumbnail previews of high‑resolution images with a blur effect and want them in SVG format for responsive design.
 * 3. When preprocessing scanned documents by blurring noise, cropping the main content area, and saving as SVG for further vector editing.
 * 4. When generating stylized icons from raster assets by applying a Gaussian blur, extracting the focal area, and converting to SVG for UI libraries.
 * 5. When automating batch processing to reduce image size, focus on the center, and store results as SVG files for printing or scaling without loss.
 */
