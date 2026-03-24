using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jp2";
        string outputPath = "output.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load JPEG2000 image
        using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = jpeg2000Image;

            // Apply emboss filter using predefined kernel
            double[,] embossKernel = ConvolutionFilter.Emboss3x3;
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(embossKernel));

            // Save processed image
            jpeg2000Image.Save(outputPath);
        }
    }
}