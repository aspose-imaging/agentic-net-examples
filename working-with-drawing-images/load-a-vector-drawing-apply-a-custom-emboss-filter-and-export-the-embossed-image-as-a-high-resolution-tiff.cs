using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector drawing and rasterize it to a high‑resolution TIFF
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Configure TIFF save options with high DPI
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);

            // Set vector rasterization options (required for vector sources)
            var vectorRasterOptions = new VectorRasterizationOptions
            {
                PageSize = vectorImage.Size,
                BackgroundColor = Color.White
            };
            tiffOptions.VectorRasterizationOptions = vectorRasterOptions;

            // Save the rasterized image as TIFF
            vectorImage.Save(outputPath, tiffOptions);
        }

        // Re‑open the TIFF, apply an emboss filter, and save the result
        using (Image img = Image.Load(outputPath))
        {
            TiffImage tiff = (TiffImage)img;

            // Apply emboss filter using a predefined convolution kernel
            tiff.Filter(tiff.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Overwrite the file with the filtered image
            tiff.Save(outputPath);
        }
    }
}