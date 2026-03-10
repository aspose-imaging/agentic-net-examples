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
        string inputPath = Path.Combine("D:", "Compressed", "example.emz");
        // Output blurred image path (PNG)
        string outputPath = Path.Combine("D:", "Compressed", "example_blurred.png");
        // Temporary rasterized PNG path
        string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_emz_raster.png");

        // Load the EMZ (vector) image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for converting vector to raster
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                PageSize = vectorImage.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // Save the vector image as a raster PNG temporarily
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };
            vectorImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG
        using (Image img = Image.Load(tempPngPath))
        {
            RasterImage rasterImage = (RasterImage)img;

            // Apply Gaussian blur filter (radius 5, sigma 4.0) to the entire image
            rasterImage.Filter(rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the blurred image
            PngOptions saveOptions = new PngOptions();
            rasterImage.Save(outputPath, saveOptions);
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}