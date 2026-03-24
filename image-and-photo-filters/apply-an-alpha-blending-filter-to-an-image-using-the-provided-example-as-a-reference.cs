using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the background image as a raster image
        using (RasterImage background = (RasterImage)Image.Load(inputPath))
        {
            // Prepare alpha blending filter options
            var blendOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ImageBlendingFilterOptions
            {
                // Use the same image as overlay for demonstration purposes
                Image = background,
                Opacity = 128, // 50% opacity
                Position = new Point(0, 0) // Top-left corner
                // BlendingMode left as default
            };

            // Apply the blending filter to the entire image
            background.Filter(background.Bounds, blendOptions);

            // Prepare PNG save options with a bound file source
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = src };

            // Save the processed image
            background.Save(outputPath, pngOptions);
        }
    }
}