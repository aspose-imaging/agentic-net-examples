using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\highres.tif";
        string outputPath = @"C:\Images\highres_embossed.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access TIFF-specific functionality
                TiffImage tiffImage = (TiffImage)image;

                // Create convolution filter options using the 5x5 Emboss kernel
                var embossKernel = ConvolutionFilter.Emboss5x5;
                var convOptions = new ConvolutionFilterOptions(embossKernel, 5, 5);

                // Apply the emboss filter to the entire image
                tiffImage.Filter(tiffImage.Bounds, convOptions);

                // Save the result as PNG
                tiffImage.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}