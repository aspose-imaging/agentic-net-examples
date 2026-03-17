using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Input EMZ file path
        string inputPath = "input.emz";
        // Output EMZ file path
        string outputPath = "output.emz";

        // Temporary files for intermediate raster images
        string tempPngPath = Path.Combine(Path.GetTempPath(), "temp.png");
        string filteredPngPath = Path.Combine(Path.GetTempPath(), "filtered.png");

        // Step 1: Rasterize the EMZ (vector) image to a PNG
        using (Image vectorImage = Image.Load(inputPath))
        {
            var rasterOptions = new EmfRasterizationOptions
            {
                PageSize = vectorImage.Size
            };
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };
            vectorImage.Save(tempPngPath, pngOptions);
        }

        // Step 2: Load the rasterized PNG and apply motion blur (motion wiener filter)
        using (Image rasterImage = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)rasterImage;
            // Apply motion wiener filter: length=10, smooth=1.0, angle=90.0
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));
            // Save the filtered raster image to another temporary PNG
            var pngOptions = new PngOptions();
            raster.Save(filteredPngPath, pngOptions);
        }

        // Step 3: Load the filtered PNG and save it back as a compressed EMZ
        using (Image filteredImage = Image.Load(filteredPngPath))
        {
            var vectorOptions = new EmfRasterizationOptions
            {
                PageSize = filteredImage.Size
            };
            var emfOptions = new EmfOptions
            {
                VectorRasterizationOptions = vectorOptions,
                Compress = true
            };
            filteredImage.Save(outputPath, emfOptions);
        }

        // Clean up temporary files
        if (File.Exists(tempPngPath))
            File.Delete(tempPngPath);
        if (File.Exists(filteredPngPath))
            File.Delete(filteredPngPath);
    }
}