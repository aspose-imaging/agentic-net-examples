using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.cdr";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR vector image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Rasterize the vector image to a memory stream as PNG
                using (MemoryStream ms = new MemoryStream())
                {
                    var rasterOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions()
                    };
                    cdr.Save(ms, rasterOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Apply Gaussian blur filter
                        raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Resize to 1200x800 using nearest neighbour resampling
                        raster.Resize(1200, 800, ResizeType.NearestNeighbourResample);

                        // Save the final image as PNG
                        raster.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}