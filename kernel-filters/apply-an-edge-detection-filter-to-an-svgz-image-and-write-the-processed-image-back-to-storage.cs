using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input SVGZ file path (compressed SVG). Provide via args or use a default path.
        string inputPath = args.Length > 0 ? args[0] : @"C:\Images\input.svgz";
        // Output PNG file path where the edge‑detected image will be saved.
        string outputPath = args.Length > 1 ? args[1] : @"C:\Images\output_edge.png";

        // Load the compressed SVG (SVGZ) image.
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare rasterization options to convert the vector image to a raster bitmap.
            VectorRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size,
                BackgroundColor = Color.White
            };

            // Temporary PNG file to hold the rasterized image.
            string tempPngPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");

            // Rasterize the SVGZ to PNG.
            PngOptions pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };
            vectorImage.Save(tempPngPath, pngSaveOptions);

            // Load the rasterized PNG as a RasterImage to apply the filter.
            using (Image rasterImg = Image.Load(tempPngPath))
            {
                RasterImage raster = (RasterImage)rasterImg;

                // Define an edge detection kernel (3x3 Laplacian).
                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Create convolution filter options with the kernel.
                ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(edgeKernel);

                // Apply the edge detection filter to the entire image.
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image.
                raster.Save(outputPath);
            }

            // Clean up the temporary rasterized PNG.
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
            }
        }
    }
}