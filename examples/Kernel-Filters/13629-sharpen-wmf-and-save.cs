using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Objects;

// Load the WMF image
string dir = @"c:\temp\";
string wmfPath = Path.Combine(dir, "sample.wmf");

// Rasterize WMF to a temporary PNG
string tempPngPath = Path.Combine(dir, "temp.png");
using (Image wmfImage = Image.Load(wmfPath))
{
    // Cast to WmfImage to access its properties
    WmfImage wmf = (WmfImage)wmfImage;

    // Set rasterization options (convert vector WMF to raster PNG)
    var rasterOptions = new PngOptions
    {
        VectorRasterizationOptions = new WmfRasterizationOptions
        {
            PageSize = wmf.Size,
            BackgroundColor = Color.White
        }
    };

    // Save rasterized image
    wmf.Save(tempPngPath, rasterOptions);
}

// Load the rasterized PNG, apply Sharpen filter, and save the result
string outputPath = Path.Combine(dir, "sample.Sharpened.png");
using (Image rasterImage = Image.Load(tempPngPath))
{
    // Cast to RasterImage to use the Filter method
    var raster = (RasterImage)rasterImage;

    // Apply Sharpen filter (kernel size 5, sigma 4.0) to the whole image
    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

    // Save the sharpened image
    raster.Save(outputPath);
}