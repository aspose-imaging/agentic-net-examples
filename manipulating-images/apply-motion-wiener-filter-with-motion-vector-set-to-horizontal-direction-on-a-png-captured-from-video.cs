using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.MotionWiener.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply MotionWiener filter with horizontal motion (angle = 0 degrees)
                // Size = 10, Sigma = 1.0 (example values)
                var options = new MotionWienerFilterOptions(10, 1.0, 0.0);
                rasterImage.Filter(rasterImage.Bounds, options);

                // Save the filtered image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}