using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "architectural.svg";
            string outputPath = "architectural_edges.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Rasterize SVG to a temporary PNG
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_raster.png");
            using (Image svgImage = Image.Load(inputPath))
            {
                VectorRasterizationOptions vectorOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                PngOptions pngOptions = new PngOptions { VectorRasterizationOptions = vectorOptions };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load raster image and apply horizontal edge detection filter
            using (Image rasterImage = Image.Load(tempPngPath))
            {
                RasterImage raster = (RasterImage)rasterImage;

                double[,] kernel = new double[,]
                {
                    { -1, -2, -1 },
                    {  0,  0,  0 },
                    {  1,  2,  1 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
                raster.Save(outputPath, new PngOptions());
            }

            // Optional cleanup of temporary file
            // File.Delete(tempPngPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}