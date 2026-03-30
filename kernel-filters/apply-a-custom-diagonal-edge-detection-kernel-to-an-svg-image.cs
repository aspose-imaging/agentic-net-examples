using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Set up rasterization options for SVG
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size
            };

            // Configure PNG save options with the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to a memory stream
            using (MemoryStream ms = new MemoryStream())
            {
                vectorImage.Save(ms, pngOptions);
                ms.Position = 0;

                // Load the rasterized image
                using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                {
                    // Define a custom diagonal edge‑detection kernel
                    double[,] kernel = new double[,]
                    {
                        { -1, 0, 1 },
                        {  0, 0, 0 },
                        {  1, 0,-1 }
                    };

                    // Create convolution filter options with the custom kernel
                    var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                    // Apply the filter to the entire image
                    rasterImage.Filter(rasterImage.Bounds, convOptions);

                    // Save the filtered image as PNG
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}