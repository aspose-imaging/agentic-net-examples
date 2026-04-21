using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.drawing";
        string outputPath = @"C:\Images\output.png";

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the drawing image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                if (image is RasterImage rasterImage)
                {
                    // Apply motion blur with size 2 and angle 0
                    // MotionWienerFilterOptions can be used for motion blur-like effect
                    rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(2, 1.0, 0.0));
                }

                // Save as PNG while preserving vector metadata (if any)
                var pngOptions = new PngOptions
                {
                    // Preserve vector metadata by setting VectorRasterizationOptions (default keeps metadata)
                    VectorRasterizationOptions = new SvgRasterizationOptions()
                };

                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}