using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Calculate half dimensions
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            // Resize using nearest neighbour resampling
            image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Prepare SVG export options with proper page size
            SvgOptions svgOptions = new SvgOptions();
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = new Size(newWidth, newHeight)
            };
            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the resized image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}