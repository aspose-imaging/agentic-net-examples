using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string[] inputPaths = { "blurred1.png", "blurred2.png", "blurred3.png" };
            string[] outputPaths = { "restored1.png", "restored2.png", "restored3.png" };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

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
                    // Cast to RasterImage to apply filters
                    RasterImage raster = (RasterImage)image;

                    // Apply deconvolution filter with default options (MotionWienerFilterOptions)
                    var deconvOptions = new MotionWienerFilterOptions(5, 1.0, 0.0);
                    raster.Filter(raster.Bounds, deconvOptions);

                    // Save the restored image
                    raster.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}