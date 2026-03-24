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
        string inputPath = @"C:\temp\input.wmf";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (Image wmfImage = Image.Load(inputPath))
        {
            // Prepare vector rasterization options for converting WMF to raster
            var rasterOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size,
                BackgroundColor = Color.White
            };

            // Convert WMF to a raster image in memory (PNG format)
            using (var memoryStream = new MemoryStream())
            {
                var pngSaveOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                wmfImage.Save(memoryStream, pngSaveOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (Image rasterImageContainer = Image.Load(memoryStream))
                {
                    var rasterImage = (RasterImage)rasterImageContainer;

                    // Apply a motion deconvolution filter
                    var deconvOptions = new MotionWienerFilterOptions(10, 1.0, 90.0);
                    rasterImage.Filter(rasterImage.Bounds, deconvOptions);

                    // Save the processed raster image
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}