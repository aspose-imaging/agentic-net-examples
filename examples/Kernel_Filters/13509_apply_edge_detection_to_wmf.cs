using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input WMF, temporary raster PNG, and final output PNG
        string inputPath = "input.wmf";
        string tempPath = "temp.png";
        string outputPath = "output.png";

        // Load the WMF image and rasterize it to a PNG file
        using (Image image = Image.Load(inputPath))
        {
            var wmfImage = (Aspose.Imaging.FileFormats.Wmf.WmfImage)image;

            var rasterOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image to a temporary PNG file
            wmfImage.Save(tempPath, pngOptions);
        }

        // Load the rasterized PNG as a RasterImage and apply an edge detection filter
        using (Image rasterImageContainer = Image.Load(tempPath))
        {
            var rasterImage = (RasterImage)rasterImageContainer;

            // Define a simple Laplacian kernel for edge detection
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            var convolutionOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

            // Apply the convolution filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, convolutionOptions);

            // Save the filtered image as PNG
            rasterImage.Save(outputPath, new PngOptions());
        }

        // Clean up the temporary file
        if (File.Exists(tempPath))
        {
            File.Delete(tempPath);
        }
    }
}