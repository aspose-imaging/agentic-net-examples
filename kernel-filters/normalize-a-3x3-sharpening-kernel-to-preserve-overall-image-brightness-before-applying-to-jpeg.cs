using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Retrieve the built‑in 3×3 sharpen kernel
            double[,] kernel = ConvolutionFilter.Sharpen3x3;

            // Compute sum of kernel elements
            double sum = 0;
            foreach (double v in kernel)
                sum += v;

            // Normalize kernel to preserve overall brightness
            double[,] normalized = new double[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    normalized[i, j] = kernel[i, j] / sum;

            // Apply the normalized sharpen filter
            var filterOptions = new ConvolutionFilterOptions(normalized);
            raster.Filter(raster.Bounds, filterOptions);

            // Save the result as JPEG
            var jpegOptions = new JpegOptions();
            raster.Save(outputPath, jpegOptions);
        }
    }
}