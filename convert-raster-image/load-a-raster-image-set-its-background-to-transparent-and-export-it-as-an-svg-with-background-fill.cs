using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // If the image is a raster image, set its background to transparent
            if (image is RasterImage rasterImage)
            {
                rasterImage.BackgroundColor = Aspose.Imaging.Color.Transparent;
                // Optionally indicate that the image now has a background color (transparent)
                rasterImage.HasBackgroundColor = true;
            }

            // Prepare SVG export options with rasterization settings
            SvgOptions svgOptions = new SvgOptions();

            // Configure rasterization options: use the original image size and a transparent background
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Aspose.Imaging.Color.Transparent
            };

            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}