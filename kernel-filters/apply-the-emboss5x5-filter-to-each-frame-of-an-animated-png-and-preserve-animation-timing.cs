using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output\\filtered.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated PNG
            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                // Apply Emboss5x5 filter to each frame
                for (int i = 0; i < apng.PageCount; i++)
                {
                    RasterImage frame = (RasterImage)apng.Pages[i];
                    frame.Filter(frame.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
                }

                // Save the modified animation, preserving original timing
                apng.Save(outputPath, new ApngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}