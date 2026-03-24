using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image emfImageBase = Image.Load(inputPath))
        {
            EmfImage emfImage = (EmfImage)emfImageBase;

            // Set up rasterization options to convert EMF to raster
            var rasterOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size,
                BackgroundColor = Color.White
            };

            // Use PNG options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize EMF into a memory stream
            using (var ms = new MemoryStream())
            {
                emfImage.Save(ms, pngOptions);
                ms.Position = 0;

                // Load the rasterized image
                using (Image rasterImageBase = Image.Load(ms))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageBase;

                    // Edge detection kernel
                    double[,] kernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    // Apply convolution filter with the edge detection kernel
                    var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                    rasterImage.Filter(rasterImage.Bounds, convOptions);

                    // Save the processed image as PNG
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}