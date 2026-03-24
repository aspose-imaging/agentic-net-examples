using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image (vector format)
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare rasterization options to convert the vector WMF to a raster image (PNG in memory)
            var rasterOptions = new PngOptions
            {
                VectorRasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = vectorImage.Size // use original size for rasterization
                }
            };

            // Rasterize the WMF into a memory stream
            using (var ms = new MemoryStream())
            {
                vectorImage.Save(ms, rasterOptions);
                ms.Position = 0; // reset stream position for reading

                // Load the rasterized image from the memory stream
                using (Image rasterImage = Image.Load(ms))
                {
                    // Cast to RasterImage to access filtering functionality
                    var raster = (RasterImage)rasterImage;

                    // Apply Gaussian blur to the whole image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed raster image to the output file
                    raster.Save(outputPath);
                }
            }
        }
    }
}