using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class MotionBlurEmfExample
{
    static void Main()
    {
        // Input EMF file path
        string inputPath = @"C:\Temp\sample.emf";

        // Output image path (raster format, e.g., PNG)
        string outputPath = @"C:\Temp\sample.MotionBlur.png";

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access EMF‑specific properties
            EmfImage emfImage = (EmfImage)image;

            // Set up rasterization options – this tells Aspose.Imaging how to render the vector EMF
            var rasterizationOptions = new EmfRasterizationOptions
            {
                // Use the original EMF size for the raster canvas
                PageSize = emfImage.Size
            };

            // Define PNG save options and attach the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize the EMF into a memory stream (PNG format)
            using (var rasterStream = new MemoryStream())
            {
                emfImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // Reset stream for reading

                // Load the rasterized image (now a RasterImage) from the memory stream
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply a motion‑blur (motion Wiener) filter to the whole image
                    // Parameters: length = 10, smooth = 1.0, angle = 90 degrees
                    raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

                    // Save the filtered raster image to the desired output file
                    raster.Save(outputPath);
                }
            }
        }
    }
}