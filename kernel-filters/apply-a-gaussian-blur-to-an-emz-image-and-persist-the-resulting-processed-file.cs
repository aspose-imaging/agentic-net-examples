// Load the compressed EMZ (vector) image
using (Aspose.Imaging.Image emzImage = Aspose.Imaging.Image.Load(@"C:\Images\input.emz"))
{
    // Rasterize the vector image to a temporary PNG in memory
    using (var pngStream = new System.IO.MemoryStream())
    {
        // Set up rasterization options for EMF/EMZ
        var rasterOptions = new Aspose.Imaging.ImageOptions.EmfRasterizationOptions
        {
            PageSize = emzImage.Size,               // Preserve original size
            BackgroundColor = Aspose.Imaging.Color.White
        };
        // Save the rasterized image as PNG to the memory stream
        emzImage.Save(pngStream,
            new Aspose.Imaging.ImageOptions.PngOptions { VectorRasterizationOptions = rasterOptions });

        // Reset stream position for reading
        pngStream.Position = 0;

        // Load the rasterized PNG as a RasterImage to apply filters
        using (Aspose.Imaging.Image rasterImg = Aspose.Imaging.Image.Load(pngStream))
        {
            var raster = (Aspose.Imaging.RasterImage)rasterImg;

            // Apply Gaussian blur to the whole image (radius 5, sigma 4.0)
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image back to a file (e.g., PNG)
            raster.Save(@"C:\Images\output_blurred.png");
        }
    }
}