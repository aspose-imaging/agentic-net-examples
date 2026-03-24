using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR image
        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            // Rasterize CDR to a PNG in memory
            using (MemoryStream ms = new MemoryStream())
            {
                var rasterOptions = new CdrRasterizationOptions
                {
                    PageSize = cdr.Size
                };
                cdr.Save(ms, new PngOptions { VectorRasterizationOptions = rasterOptions });
                ms.Position = 0;

                // Load rasterized image
                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    // Emboss kernel (3x3)
                    double[,] embossKernel = new double[,]
                    {
                        { -2, -1, 0 },
                        { -1, 1, 1 },
                        { 0, 1, 2 }
                    };

                    // Apply emboss filter
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(embossKernel));

                    // Save the processed image
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}