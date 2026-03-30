using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Define a simple edge detection kernel (3x3)
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1, 8, -1 },
                { -1, -1, -1 }
            };
            double factor = 1.0;
            int bias = 0;

            // Create convolution filter options
            var filterOptions = new ConvolutionFilterOptions(kernel, factor, bias);

            // Apply the convolution filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Save the filtered image to a memory stream (PNG format)
            using (MemoryStream ms = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions();
                raster.Save(ms, pngOptions);
                ms.Position = 0;

                // Write the memory stream to the output file
                using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    ms.CopyTo(fs);
                }
            }
        }
    }
}