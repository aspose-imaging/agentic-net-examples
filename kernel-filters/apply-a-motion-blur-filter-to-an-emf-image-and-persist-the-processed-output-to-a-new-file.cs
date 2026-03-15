using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input EMF file path
        string inputPath = @"C:\Images\input.emf";
        // Output EMF file path
        string outputPath = @"C:\Images\output.emf";
        // Temporary raster file path
        string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_emf_raster.png");

        // Load the EMF image
        using (Image emfImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for converting EMF to raster (PNG)
            var rasterizationOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // Save the EMF as a raster PNG image
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };
            emfImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG image
        using (Image rasterImageContainer = Image.Load(tempPngPath))
        {
            var rasterImage = (RasterImage)rasterImageContainer;

            // Apply motion‑wiener (motion blur) filter to the entire image
            var motionFilter = new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0);
            rasterImage.Filter(rasterImage.Bounds, motionFilter);

            // Prepare EMF save options (re‑rasterize to EMF)
            var emfSaveOptions = new EmfOptions
            {
                VectorRasterizationOptions = new EmfRasterizationOptions
                {
                    PageSize = rasterImage.Size,
                    BackgroundColor = Aspose.Imaging.Color.White
                }
            };

            // Save the filtered image back to EMF format
            rasterImage.Save(outputPath, emfSaveOptions);
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}