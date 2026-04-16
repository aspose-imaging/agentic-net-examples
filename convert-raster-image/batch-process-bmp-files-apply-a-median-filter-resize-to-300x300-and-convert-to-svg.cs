using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Set up base, input, and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists; create if missing
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add BMP files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (string inputPath in files)
        {
            // Process only BMP files
            if (!Path.GetExtension(inputPath).Equals(".bmp", StringComparison.OrdinalIgnoreCase))
                continue;

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output SVG path
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".svg";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure output directory exists for this file
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image, apply median filter, resize, and save as SVG
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for raster operations
                RasterImage raster = (RasterImage)image;

                // Apply median filter with kernel size 5
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

                // Resize to 300x300 pixels
                raster.Resize(300, 300);

                // Prepare SVG save options with rasterization settings
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = raster.Size
                    }
                };

                // Save the processed image as SVG
                raster.Save(outputPath, svgOptions);
            }
        }
    }
}