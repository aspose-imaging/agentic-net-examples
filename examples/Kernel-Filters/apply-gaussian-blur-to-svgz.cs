// Path to the source SVGZ file
string inputPath = @"C:\Images\source.svgz";

// Path where the blurred result will be saved (PNG format)
string outputPath = @"C:\Images\blurred.png";

using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
{
    // Rasterize the SVGZ into a PNG stored in a memory stream
    using (var rasterStream = new System.IO.MemoryStream())
    {
        var rasterOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions
        {
            // Use the original SVG size for rasterization
            PageSize = svgImage.Size
        };

        var pngOptions = new Aspose.Imaging.ImageOptions.PngOptions
        {
            VectorRasterizationOptions = rasterOptions
        };

        // Save the rasterized image into the memory stream
        svgImage.Save(rasterStream, pngOptions);
        rasterStream.Position = 0; // Reset stream for reading

        // Load the rasterized image (now a RasterImage) from the memory stream
        using (Aspose.Imaging.Image rasterImage = Aspose.Imaging.Image.Load(rasterStream))
        {
            var raster = (Aspose.Imaging.RasterImage)rasterImage;

            // Apply Gaussian blur filter to the whole image
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the blurred raster image to the desired output file
            raster.Save(outputPath);
        }
    }
}