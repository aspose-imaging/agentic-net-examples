using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "Input";
            string outputDir = "Output";

            // Ensure input directory exists; create if missing and exit
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add PNG files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.png");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_MotionWiener.png";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists before saving
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply MotionWiener filter, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    // Apply motion Wiener filter: length=10, smooth=1.0, angle=90.0
                    raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));
                    raster.Save(outputPath, new PngOptions());
                }

                Console.WriteLine($"Processed: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}