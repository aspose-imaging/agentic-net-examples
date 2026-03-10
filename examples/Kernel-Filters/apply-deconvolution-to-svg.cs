using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class DeconvolutionOnSvg
{
    static void Main()
    {
        // Input SVG file path
        string inputSvgPath = @"c:\temp\input.svg";

        // Temporary rasterized PNG path
        string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_rasterized.png");

        // Output PNG path after applying deconvolution filter
        string outputPngPath = @"c:\temp\output_deconvolution.png";

        // 1. Load the SVG image
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // 2. Rasterize the SVG to PNG (no filter applied yet)
            // VectorRasterizationOptions are required for rasterizing vector formats
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size // preserve original size
            };

            var pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            svgImage.Save(tempPngPath, pngSaveOptions);
        }

        // 3. Load the rasterized PNG as a RasterImage
        using (Image rasterImage = Image.Load(tempPngPath))
        {
            // Cast to RasterImage to access the Filter method
            var raster = rasterImage as RasterImage;
            if (raster == null)
                throw new InvalidOperationException("Failed to cast loaded image to RasterImage.");

            // 4. Apply a deconvolution filter (Gauss-Wiener) to the whole image
            // Parameters: radius = 5, sigma = 4.0 (example values)
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0);
            raster.Filter(raster.Bounds, deconvOptions);

            // 5. Save the filtered image
            raster.Save(outputPngPath);
        }

        // Optional: clean up temporary file
        if (File.Exists(tempPngPath))
            File.Delete(tempPngPath);
    }
}