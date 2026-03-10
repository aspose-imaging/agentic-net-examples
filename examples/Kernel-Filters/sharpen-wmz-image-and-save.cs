// Load the compressed WMZ image
using (Aspose.Imaging.Image wmzImage = Aspose.Imaging.Image.Load(@"C:\Images\sample.wmz"))
{
    // Prepare rasterization options to convert the vector WMZ to a raster format (PNG)
    Aspose.Imaging.ImageOptions.WmfRasterizationOptions rasterOptions =
        new Aspose.Imaging.ImageOptions.WmfRasterizationOptions()
        {
            PageSize = wmzImage.Size,               // Use original size
            BackgroundColor = Aspose.Imaging.Color.White // Optional background
        };

    // Save the rasterized image to a memory stream as PNG
    using (var pngStream = new System.IO.MemoryStream())
    {
        wmzImage.Save(pngStream,
            new Aspose.Imaging.ImageOptions.PngOptions()
            {
                VectorRasterizationOptions = rasterOptions
            });

        // Reset stream position for reading
        pngStream.Position = 0;

        // Load the rasterized PNG as a RasterImage to apply filters
        using (Aspose.Imaging.Image rasterImg = Aspose.Imaging.Image.Load(pngStream))
        {
            Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)rasterImg;

            // Apply a sharpen filter to the whole image
            rasterImage.Filter(
                rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the sharpened result
            rasterImage.Save(@"C:\Images\sample_sharpened.png");
        }
    }
}