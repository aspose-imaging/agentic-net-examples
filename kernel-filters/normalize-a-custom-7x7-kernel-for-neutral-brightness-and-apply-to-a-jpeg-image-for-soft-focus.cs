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
        string inputPath = "input\\photo.jpg";
        string outputPath = "output\\soft_focus.jpg";

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

            // Define a custom 7x7 kernel (example values)
            double[,] kernel = new double[7, 7]
            {
                { 1, 2, 3, 4, 3, 2, 1 },
                { 2, 4, 6, 8, 6, 4, 2 },
                { 3, 6, 9,12, 9, 6, 3 },
                { 4, 8,12,16,12, 8, 4 },
                { 3, 6, 9,12, 9, 6, 3 },
                { 2, 4, 6, 8, 6, 4, 2 },
                { 1, 2, 3, 4, 3, 2, 1 }
            };

            // Compute sum of kernel elements
            double sum = 0;
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    sum += kernel[i, j];

            // Normalize kernel to ensure neutral brightness (sum = 1)
            double[,] normalizedKernel = new double[7, 7];
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    normalizedKernel[i, j] = kernel[i, j] / sum;

            // Create convolution filter options with the normalized kernel
            ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(normalizedKernel);

            // Apply the custom soft‑focus filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Prepare JPEG save options
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90
            };

            // Save the processed image
            raster.Save(outputPath, jpegOptions);
        }
    }
}