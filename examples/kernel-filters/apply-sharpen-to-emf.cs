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
        string inputEmfPath = @"C:\Images\input.emf";
        // Output raster image path (PNG with sharpen filter applied)
        string outputPngPath = @"C:\Images\output_sharpened.png";

        // Load the EMF image
        using (Image image = Image.Load(inputEmfPath))
        {
            // Cast to EmfImage to access EMF‑specific properties
            EmfImage emfImage = (EmfImage)image;

            // Prepare rasterization options – this will render the vector EMF to a raster bitmap
            EmfRasterizationOptions rasterizationOptions = new EmfRasterizationOptions
            {
                // Use the original EMF size for the rasterized bitmap
                PageSize = emfImage.Size
            };

            // Set up PNG save options with the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize the EMF into a memory stream (PNG format)
            using (MemoryStream rasterStream = new MemoryStream())
            {
                emfImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image as a RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                {
                    // Apply a sharpen filter to the whole image
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new SharpenFilterOptions(5, 4.0) // kernel size = 5, sigma = 4.0
                    );

                    // Save the sharpened raster image
                    rasterImage.Save(outputPngPath);
                }
            }
        }
    }
}