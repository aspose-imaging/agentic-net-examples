using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.tif";

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
            // Cast to TiffImage to access filtering functionality
            TiffImage tiffImage = (TiffImage)image;

            // Apply a Gauss-Wiener deconvolution filter to the entire image
            tiffImage.Filter(
                tiffImage.Bounds,
                new GaussWienerFilterOptions(5, 4.0));

            // Save the processed image as BigTIFF
            var saveOptions = new BigTiffOptions(TiffExpectedFormat.Default);
            tiffImage.Save(outputPath, saveOptions);
        }
    }
}