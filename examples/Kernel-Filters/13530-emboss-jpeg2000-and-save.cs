using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.j2k";
        string outputPath = "output_embossed.j2k";

        // Load the JPEG2000 image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage raster = (RasterImage)image;

            // Apply emboss filter using the predefined Emboss3x3 kernel
            raster.Filter(
                raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

            // Set JPEG2000 save options (optional: use irreversible compression)
            Jpeg2000Options saveOptions = new Jpeg2000Options
            {
                Irreversible = true
            };

            // Save the processed image
            raster.Save(outputPath, saveOptions);
        }
    }
}