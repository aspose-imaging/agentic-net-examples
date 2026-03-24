using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emz";
        string outputPath = @"C:\Images\sample_embossed.emz";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMZ (vector) image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for converting vector to raster
            var rasterOptions = new EmfRasterizationOptions
            {
                PageSize = vectorImage.Size,
                BackgroundColor = Color.White
            };

            // Rasterize the vector image into a PNG stored in memory
            using (var pngStream = new MemoryStream())
            {
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                vectorImage.Save(pngStream, pngOptions);
                pngStream.Position = 0;

                // Load the rasterized image
                using (Image rasterImage = Image.Load(pngStream))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply Emboss filter using convolution kernel
                    var embossOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3);
                    raster.Filter(raster.Bounds, embossOptions);

                    // Save the filtered raster back to EMZ format (compressed EMF)
                    var emfOptions = new EmfOptions
                    {
                        Compress = true,
                        VectorRasterizationOptions = rasterOptions
                    };
                    raster.Save(outputPath, emfOptions);
                }
            }
        }
    }
}