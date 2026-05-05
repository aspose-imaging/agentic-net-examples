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
            string inputPath = "input/multipage.svg";
            string outputDir = "output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Check if the image supports multiple pages
                if (image is IMultipageImage multipageImage && multipageImage.PageCount > 0)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        // Get the current page
                        using (Image pageImage = multipageImage.Pages[i])
                        {
                            // Rasterize the page to a PNG in memory
                            using (MemoryStream ms = new MemoryStream())
                            {
                                // Set up vector rasterization options
                                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                                {
                                    PageSize = pageImage.Size
                                };

                                // Save the page as PNG to the memory stream
                                PngOptions pngOptions = new PngOptions
                                {
                                    VectorRasterizationOptions = vectorOptions
                                };
                                pageImage.Save(ms, pngOptions);
                                ms.Position = 0;

                                // Load the rasterized page
                                using (RasterImage raster = (RasterImage)Image.Load(ms))
                                {
                                    // Define a custom 3x3 convolution kernel (sharpen)
                                    double[,] kernel = new double[,]
                                    {
                                        { 0, -1, 0 },
                                        { -1, 5, -1 },
                                        { 0, -1, 0 }
                                    };

                                    // Create convolution filter options
                                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                                    // Apply the convolution filter to the entire image
                                    raster.Filter(raster.Bounds, filterOptions);

                                    // Save the filtered page
                                    string outputPath = Path.Combine(outputDir, $"page_{i}.png");
                                    raster.Save(outputPath, new PngOptions());
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The image does not support multiple pages.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}