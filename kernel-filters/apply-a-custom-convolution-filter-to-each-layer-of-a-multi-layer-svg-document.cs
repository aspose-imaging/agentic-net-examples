using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var embeddedImages = (image as VectorImage)?.GetEmbeddedImages();

                if (embeddedImages != null)
                {
                    foreach (var embedded in embeddedImages)
                    {
                        if (embedded.Image is RasterImage raster)
                        {
                            double[,] kernel = new double[,]
                            {
                                { 0, -1, 0 },
                                { -1, 5, -1 },
                                { 0, -1, 0 }
                            };

                            var filterOptions = new ConvolutionFilterOptions(kernel, 0, 1);
                            raster.Filter(raster.Bounds, filterOptions);
                        }
                    }
                }

                image.Save(outputPath, new SvgOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}