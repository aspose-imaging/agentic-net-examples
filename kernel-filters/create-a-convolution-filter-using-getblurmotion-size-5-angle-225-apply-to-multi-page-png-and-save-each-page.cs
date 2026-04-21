using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
                    return;
                }

                // Prepare convolution kernel once
                double[,] kernel = ConvolutionFilter.GetBlurMotion(5, 225);
                var filterOptions = new ConvolutionFilterOptions(kernel);

                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Each page is an Image; cast to RasterImage for filtering
                    using (RasterImage raster = (RasterImage)multipage.Pages[i])
                    {
                        // Apply the motion blur convolution filter to the entire page
                        raster.Filter(raster.Bounds, filterOptions);

                        // Build output path for the current page
                        string outputPath = Path.Combine(outputDir, $"page_{i}.png");

                        // Ensure the directory for this output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the filtered page as PNG
                        PngOptions pngOptions = new PngOptions();
                        raster.Save(outputPath, pngOptions);
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