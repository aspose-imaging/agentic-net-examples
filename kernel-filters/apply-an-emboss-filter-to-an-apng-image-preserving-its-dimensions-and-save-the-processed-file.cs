using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output_embossed.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Apply Emboss filter to each frame
            for (int i = 0; i < apng.PageCount; i++)
            {
                RasterImage frame = (RasterImage)apng.Pages[i];
                frame.Filter(
                    frame.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
            }

            // Save the processed APNG, preserving dimensions
            apng.Save(outputPath, new ApngOptions());
        }
    }
}