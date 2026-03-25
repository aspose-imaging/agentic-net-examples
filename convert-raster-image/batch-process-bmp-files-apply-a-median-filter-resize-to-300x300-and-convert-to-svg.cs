using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input BMP files
        string[] inputFiles = new[]
        {
            @"C:\Images\sample1.bmp",
            @"C:\Images\sample2.bmp"
        };

        // Hard‑coded output folder for SVG files
        string outputFolder = @"C:\Images\output";

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output SVG path
            string outputPath = Path.Combine(outputFolder,
                Path.GetFileNameWithoutExtension(inputPath) + ".svg");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access raster operations
                RasterImage raster = (RasterImage)image;

                // Apply median filter with size 5 to the whole image
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Resize to 300x300 pixels (default nearest‑neighbour resample)
                raster.Resize(300, 300);

                // Save as SVG using default SvgOptions
                SvgOptions svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
            }
        }
    }
}