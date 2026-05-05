using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Input image URL
            string inputUrl = "https://example.com/sample.png";

            // Load image from the network URL
            using (Image image = Image.Load(inputUrl))
            {
                RasterImage raster = (RasterImage)image;

                // Apply the Emboss3x3 convolution filter to the entire image
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // No saving to disk as required
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}