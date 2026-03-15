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
        // Input EMF file path
        string inputPath = "input.emf";
        // Output PNG file path (processed image)
        string outputPath = "output.png";
        // Temporary PNG file to hold rasterized EMF
        string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_emf_raster.png");

        // Rasterize EMF to PNG
        using (Image emfImage = Image.Load(inputPath))
        {
            // Set up vector rasterization options
            var vectorOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size,
                BackgroundColor = Color.White
            };

            // Use PNG options with vector rasterization to produce raster image
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            // Save rasterized image to temporary PNG file
            emfImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply Gaussian blur, and save the result
        using (Image rasterImage = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)rasterImage;

            // Apply Gaussian blur with radius 5 and sigma 4.0
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image
            raster.Save(outputPath, new PngOptions());
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}