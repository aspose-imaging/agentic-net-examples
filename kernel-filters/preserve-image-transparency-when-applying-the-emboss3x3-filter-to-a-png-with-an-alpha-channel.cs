using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            // Define Emboss3x3 kernel manually
            double[,] embossKernel = new double[,]
            {
                { -2, -1, 0 },
                { -1,  1, 1 },
                {  0,  1, 2 }
            };

            // Create convolution filter options with the kernel
            var filterOptions = new ConvolutionFilterOptions(embossKernel);

            // Apply the filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Prepare PNG save options preserving alpha channel
            var pngOptions = new PngOptions
            {
                ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha
            };

            // Save the processed image
            raster.Save(outputPath, pngOptions);
        }
    }
}