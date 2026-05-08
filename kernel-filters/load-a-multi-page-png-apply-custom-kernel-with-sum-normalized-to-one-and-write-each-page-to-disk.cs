using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input path
            string inputPath = "input.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Ensure the image supports multiple pages
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
                    return;
                }

                // Define a 3x3 kernel and normalize its sum to 1
                double[,] kernel = new double[,]
                {
                    { 1, 1, 1 },
                    { 1, 1, 1 },
                    { 1, 1, 1 }
                };
                double sum = 0;
                foreach (double v in kernel) sum += v;
                for (int i = 0; i < kernel.GetLength(0); i++)
                    for (int j = 0; j < kernel.GetLength(1); j++)
                        kernel[i, j] /= sum;

                // Output directory (ensured to exist)
                string outputDir = "output";
                Directory.CreateDirectory(outputDir);

                // Process each page
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Retrieve the page as a raster image
                    Image pageImage = multipage.Pages[i];
                    using (RasterImage raster = pageImage as RasterImage)
                    {
                        if (raster == null)
                        {
                            Console.Error.WriteLine($"Page {i} is not a raster image.");
                            continue;
                        }

                        // Apply the custom convolution filter
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                        // Prepare output path for this page
                        string outputPath = Path.Combine(outputDir, $"page_{i}.png");

                        // Ensure the output directory exists (unconditional call)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the processed page
                        PngOptions options = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };
                        raster.Save(outputPath, options);
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