using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDir = "Input";
        string outputDir = "Output";

        // Ensure input directory exists
        if (!Directory.Exists(inputDir))
        {
            Directory.CreateDirectory(inputDir);
            Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Get all files in the input directory
        string[] files = Directory.GetFiles(inputDir);
        foreach (string inputPath in files)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Prepare output path with .svg extension
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".svg");

            // Ensure output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load, process, and save the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for raster operations
                RasterImage raster = (RasterImage)image;

                // Resize to 800x800 (default NearestNeighbourResample)
                raster.Resize(800, 800);

                // Apply Gaussian blur (radius 5, sigma 4.0)
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare SVG save options with rasterization settings
                SvgOptions svgOptions = new SvgOptions();
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = raster.Size
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                raster.Save(outputPath, svgOptions);
            }
        }
    }
}