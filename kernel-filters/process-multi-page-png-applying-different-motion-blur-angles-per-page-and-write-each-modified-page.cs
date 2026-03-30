using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputDirectory = "output";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the multi‑page PNG
        using (Image image = Image.Load(inputPath))
        {
            // Check if the loaded image supports multiple pages
            if (image is IMultipageImage multipageImage)
            {
                int pageCount = multipageImage.PageCount;

                for (int i = 0; i < pageCount; i++)
                {
                    // Retrieve the page as an Image
                    Image page = multipageImage.Pages[i];

                    // Cast to RasterImage for processing
                    using (RasterImage raster = (RasterImage)page)
                    {
                        // Define motion blur parameters per page
                        int length = 10;                     // example length
                        double sigma = 1.0;                  // example sigma
                        double angle = i * 30.0;             // different angle for each page

                        // Apply motion Wiener filter (motion blur)
                        raster.Filter(
                            raster.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(length, sigma, angle));

                        // Prepare output file path for this page
                        string outputPath = Path.Combine(outputDirectory, $"page_{i}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the modified page as PNG
                        raster.Save(outputPath, new PngOptions());
                    }
                }
            }
            else
            {
                Console.Error.WriteLine("The loaded image does not support multiple pages.");
            }
        }
    }
}