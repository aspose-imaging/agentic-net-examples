using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\multipage.svg";
            string outputDir = @"C:\temp\output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the multipage SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to multipage interface
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage != null ? multipage.PageCount : 1;

                for (int i = 0; i < pageCount; i++)
                {
                    // Export current page to a temporary PNG
                    string tempPngPath = Path.Combine(outputDir, $"page_{i}.png");
                    PngOptions pngOptions = new PngOptions
                    {
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1)),
                        VectorRasterizationOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions
                        {
                            PageSize = image.Size
                        }
                    };
                    image.Save(tempPngPath, pngOptions);

                    // Load the exported PNG as a raster image
                    using (Image rasterImg = Image.Load(tempPngPath))
                    {
                        var raster = (RasterImage)rasterImg;

                        // Define a custom 3x3 convolution kernel (sharpen example)
                        double[,] kernel = new double[,]
                        {
                            { 0, -1,  0 },
                            { -1, 5, -1 },
                            { 0, -1,  0 }
                        };

                        // Apply the convolution filter to the entire image
                        raster.Filter(raster.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                        // Save the filtered image
                        string filteredPath = Path.Combine(outputDir, $"page_{i}_filtered.png");
                        raster.Save(filteredPath);
                    }

                    // Optionally delete the intermediate unfiltered PNG
                    File.Delete(tempPngPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}