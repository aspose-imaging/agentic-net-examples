using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hardcoded input SVG file
        string inputPath = @"C:\temp\sample.svg";

        // Hardcoded output files for each filter
        string outputPath3x3 = @"C:\temp\output\sample_Emboss3x3.png";
        string outputPath5x5 = @"C:\temp\output\sample_Emboss5x5.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath3x3));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath5x5));

        // ---------- Apply 3x3 Emboss ----------
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            using (RasterImage raster = (RasterImage)image)
            {
                // Apply the 3x3 emboss kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                // Save the result
                raster.Save(outputPath3x3);
            }
        }

        // ---------- Apply 5x5 Emboss ----------
        using (Image image = Image.Load(inputPath))
        {
            using (RasterImage raster = (RasterImage)image)
            {
                // Apply the 5x5 emboss kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
                // Save the result
                raster.Save(outputPath5x5);
            }
        }

        Console.WriteLine("Emboss filtering completed.");
    }
}