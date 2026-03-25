using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG save options with background color
            SvgOptions saveOptions = new SvgOptions();

            // Configure rasterization options
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set light gray background
                BackgroundColor = Aspose.Imaging.Color.LightGray,
                // Use the original image size as page size
                PageSize = image.Size
            };

            saveOptions.VectorRasterizationOptions = rasterOptions;

            // Save as SVG with the specified background
            image.Save(outputPath, saveOptions);
        }
    }
}