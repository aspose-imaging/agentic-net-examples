using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input, overlay, and output paths
        string inputPath = "input.jpg";
        string overlayPath = "overlay.png";
        string outputPath = "output.png";

        // Validate input files
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }
        if (!File.Exists(overlayPath))
        {
            Console.Error.WriteLine($"File not found: {overlayPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load background image
        using (RasterImage background = (RasterImage)Image.Load(inputPath))
        {
            // Load overlay image
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                // Configure blending filter options
                ImageBlendingFilterOptions blendOptions = new ImageBlendingFilterOptions
                {
                    Image = overlay,
                    Opacity = 128, // 50% opacity
                    BlendingMode = BlendingMode.Normal
                };

                // Apply blending filter to the entire background image
                background.Filter(background.Bounds, blendOptions);
            }

            // Prepare PNG save options with bound source
            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions { Source = outputSource };

            // Save the blended image
            background.Save(outputPath, pngOptions);
        }
    }
}