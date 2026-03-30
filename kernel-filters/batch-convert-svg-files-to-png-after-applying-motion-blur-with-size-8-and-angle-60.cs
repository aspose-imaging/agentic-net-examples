using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Set up base, input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
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
            // Process only SVG files
            if (!Path.GetExtension(inputPath).Equals(".svg", StringComparison.OrdinalIgnoreCase))
                continue;

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string tempPngPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_temp.png");
            string finalPngPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

            // Rasterize SVG to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                using (PngOptions pngOptions = new PngOptions())
                {
                    // Set vector rasterization options for SVG
                    pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height
                    };

                    // Ensure directory for temporary file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
                    svgImage.Save(tempPngPath, pngOptions);
                }
            }

            // Load the rasterized PNG, apply motion blur, and save final PNG
            using (Image rasterImage = Image.Load(tempPngPath))
            {
                RasterImage raster = (RasterImage)rasterImage;

                // Apply motion blur filter with size 8, brightness 1.0, angle 60 degrees
                raster.Filter(raster.Bounds, new MotionWienerFilterOptions(8, 1.0, 60.0));

                // Ensure output directory exists before saving
                Directory.CreateDirectory(Path.GetDirectoryName(finalPngPath));
                using (PngOptions finalOptions = new PngOptions())
                {
                    raster.Save(finalPngPath, finalOptions);
                }
            }

            // Optionally delete the temporary file
            try
            {
                File.Delete(tempPngPath);
            }
            catch
            {
                // Ignore any errors during cleanup
            }
        }
    }
}