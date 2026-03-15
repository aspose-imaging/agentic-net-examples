using System;
using System.Drawing; // For Rectangle
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class EdgeDetectionExample
{
    static void Main()
    {
        // Path to the source DIB (BMP) image
        string sourcePath = @"C:\Temp\sample.dib";

        // Path where the processed image will be saved
        string outputPath = @"C:\Temp\sample.EdgeDetected.png";

        // Load the image using Aspose.Imaging's load rule
        using (Image image = Image.Load(sourcePath))
        {
            // Most raster formats (including DIB) derive from RasterImage,
            // so we can safely cast to RasterImage to access the Filter method.
            RasterImage raster = (RasterImage)image;

            // Apply an edge‑enhancing filter.
            // Aspose.Imaging does not have a dedicated EdgeDetection filter,
            // but the Sharpen filter highlights edges effectively.
            raster.Filter(
                raster.Bounds,                         // Apply to the whole image
                new SharpenFilterOptions(5, 4.0)      // Kernel size 5, sigma 4.0
            );

            // Save the transformed image using the save rule.
            // PNG is chosen for lossless output.
            raster.Save(outputPath, new PngOptions());
        }
    }
}