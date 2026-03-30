using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\face_input.jpg";
        string outputPath = @"C:\Images\face_output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image, apply Emboss5x5 filter, and save
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply Emboss5x5 convolution filter to the entire image
            var embossOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5);
            raster.Filter(raster.Bounds, embossOptions);

            // Save the filtered image
            raster.Save(outputPath);
        }

        // TODO: Run face detection algorithm on the filtered image at outputPath
    }
}