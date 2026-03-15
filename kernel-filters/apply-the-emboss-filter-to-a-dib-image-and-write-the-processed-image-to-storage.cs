using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define input DIB image path and output BMP image path
        string inputPath = "input.dib";
        string outputPath = "output.bmp";

        // Load the DIB image as a raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Apply the emboss filter using the predefined 5x5 kernel
            rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

            // Set up BMP save options with a file create source
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions saveOptions = new BmpOptions() { Source = source };

            // Save the processed image to storage
            rasterImage.Save(outputPath, saveOptions);
        }
    }
}