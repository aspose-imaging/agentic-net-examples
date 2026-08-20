// HOW-TO: Apply Custom Convolution Kernel To Each Page Of A Multi-Page SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputDirectory = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional as per rule)
            Directory.CreateDirectory(outputDirectory);

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Determine if the image supports multiple pages
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage != null ? multipage.PageCount : 1;

                // Custom convolution kernel (sharpen example)
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                for (int i = 0; i < pageCount; i++)
                {
                    // Prepare rasterization options for the current page
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Prepare PNG options with page selection and rasterization settings
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions,
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1))
                    };

                    // Rasterize the selected page into a memory stream
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load the rasterized image as a RasterImage
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Apply the custom convolution filter
                            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                            // Define output path for the processed page
                            string outputPath = Path.Combine(outputDirectory, $"page_{i}.png");

                            // Ensure the output directory exists (unconditional)
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the filtered raster image
                            raster.Save(outputPath, new PngOptions());
                        }
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

/*
 * Real-World Use Cases:
 * 1. When you need to sharpen every layer of a multi-page SVG before converting it to PNG for web publishing.
 * 2. When you want to batch-process vector illustrations that contain multiple artboards, applying a custom filter to each page programmatically.
 * 3. When an automated pipeline must rasterize each page of an SVG logo set and enhance contrast using a convolution matrix.
 * 4. When you are building a C# tool that extracts individual pages from a multi-page SVG and applies edge-detection before saving them as PNG files.
 * 5. When you require consistent image processing across all pages of a multi-page SVG, such as applying a custom blur or emboss kernel in a .NET application.
 */
