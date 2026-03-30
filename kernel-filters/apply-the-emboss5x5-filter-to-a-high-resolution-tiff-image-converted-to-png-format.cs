using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\high_res_input.tif";
        string outputPath = @"C:\Images\high_res_output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to gain access to the Filter method
            TiffImage tiffImage = (TiffImage)image;

            // Apply the 5x5 emboss convolution filter to the whole image
            var embossKernel = ConvolutionFilter.Emboss5x5; // double[] kernel
            var embossOptions = new ConvolutionFilterOptions(embossKernel, 5, 5);
            tiffImage.Filter(tiffImage.Bounds, embossOptions);

            // Save the processed image as PNG
            var pngSaveOptions = new PngOptions();
            tiffImage.Save(outputPath, pngSaveOptions);
        }
    }
}