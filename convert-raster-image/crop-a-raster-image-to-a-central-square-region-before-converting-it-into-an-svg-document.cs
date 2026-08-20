// HOW-TO: Crop Central Square From PNG and Convert To SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for cropping
                RasterImage rasterImage = (RasterImage)image;

                // Determine central square region
                int size = Math.Min(rasterImage.Width, rasterImage.Height);
                int left = (rasterImage.Width - size) / 2;
                int top = (rasterImage.Height - size) / 2;

                // Crop to the central square
                Aspose.Imaging.Rectangle cropArea = new Aspose.Imaging.Rectangle(left, top, size, size);
                rasterImage.Crop(cropArea);

                // Save the cropped image as SVG
                SvgOptions svgOptions = new SvgOptions();
                rasterImage.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a square thumbnail from a rectangular PNG for use in a web UI and store it as a scalable SVG.
 * 2. When preparing product images for a responsive design that requires a centered square vector version without losing quality.
 * 3. When converting scanned photos into SVG icons, ensuring the focus area remains centered by cropping to a square first.
 * 4. When automating batch processing of user‑uploaded images to create uniform SVG avatars from the central portion of each picture.
 * 5. When integrating Aspose.Imaging into a C# application to transform raster graphics into vector format while standardizing dimensions for printing.
 */
