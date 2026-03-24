using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = "input\\sample.emf";
        string tempPath = "temp\\raster.png";
        string outputPath = "output\\processed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EMF and rasterize to PNG
        using (Image emfImage = Image.Load(inputPath))
        {
            var vectorOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size,
                BackgroundColor = Color.White
            };
            var pngOptions = new PngOptions { VectorRasterizationOptions = vectorOptions };
            emfImage.Save(tempPath, pngOptions);
        }

        // Load rasterized image, apply deconvolution filter, and save result
        using (Image rasterImg = Image.Load(tempPath))
        {
            RasterImage raster = (RasterImage)rasterImg;
            var deconvOptions = new MotionWienerFilterOptions(10, 1.0, 45.0);
            raster.Filter(raster.Bounds, deconvOptions);
            raster.Save(outputPath, new PngOptions());
        }
    }
}