using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image emfImage = Image.Load(inputPath))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Rasterize EMF to PNG in memory
                PngOptions rasterizeOptions = new PngOptions();
                EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions();
                vectorOptions.PageSize = emfImage.Size;
                rasterizeOptions.VectorRasterizationOptions = vectorOptions;

                emfImage.Save(ms, rasterizeOptions);
                ms.Position = 0;

                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    // Apply Gaussian blur with radius 5 and sigma 4.0
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the blurred image as PNG
                    PngOptions saveOptions = new PngOptions();
                    raster.Save(outputPath, saveOptions);
                }
            }
        }
    }
}