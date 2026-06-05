using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Process each BMP file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDir, "*.bmp"))
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output SVG path
                string outputPath = Path.Combine(outputDir,
                    Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure output directory exists (unconditional as per rules)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for filtering and resizing
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply median filter with size 5
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Resize to 300x300 pixels
                    rasterImage.Resize(300, 300);

                    // Save as SVG using default SvgOptions
                    rasterImage.Save(outputPath, new SvgOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}