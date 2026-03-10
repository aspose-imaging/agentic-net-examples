using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Input EMF file path
        string inputPath = @"C:\Images\input.emf";
        // Output blurred image path (PNG format)
        string outputPath = @"C:\Images\output_blur.png";

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access EMF‑specific properties
            EmfImage emfImage = (EmfImage)image;

            // Prepare rasterization options to convert the vector EMF to a raster image
            var rasterizationOptions = new EmfRasterizationOptions
            {
                // Use the original EMF size for the raster canvas
                PageSize = emfImage.Size,
                // Set a background color (optional)
                BackgroundColor = Color.White
            };

            // Define PNG save options that include the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize the EMF image into a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                emfImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image from the memory stream
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    // Cast to RasterImage to use the Filter method
                    var raster = (RasterImage)rasterImage;

                    // Apply a Gaussian blur filter (radius = 5, sigma = 4.0) to the whole image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the blurred raster image to the desired output file
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}