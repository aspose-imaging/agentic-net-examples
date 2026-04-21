using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Configure high‑resolution rasterization (e.g., 3× scaling)
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = epsImage.Width * 3,
                PageHeight = epsImage.Height * 3
            };

            // Rasterize EPS to PNG in memory
            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                epsImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load rasterized image
                using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                {
                    // Apply sharpening filter (kernel size 5, sigma 4.0)
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                    // Save as high‑quality JPEG
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 100
                    };
                    raster.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}