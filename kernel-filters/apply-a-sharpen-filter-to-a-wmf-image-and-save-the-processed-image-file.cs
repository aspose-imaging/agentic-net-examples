using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class SharpenWmfExample
{
    static void Main()
    {
        // Folder containing the source WMF file
        string dir = @"c:\temp\";

        // Load the WMF image
        using (Image wmfImage = Image.Load(Path.Combine(dir, "sample.wmf")))
        {
            // Prepare rasterization options to convert WMF to a raster format (PNG)
            var rasterizationOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size,               // Preserve original size
                BackgroundColor = Color.White           // Set background color for rasterization
            };

            // Set PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize WMF into a memory stream (PNG format)
            using (var rasterStream = new MemoryStream())
            {
                wmfImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image (now a RasterImage)
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply Sharpen filter to the entire image
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the sharpened image to disk
                    string outputPath = Path.Combine(dir, "sample_sharpened.png");
                    raster.Save(outputPath);
                }
            }
        }
    }
}