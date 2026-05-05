using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output\\processed.tif";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the multipage TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Edge detection kernel
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Process each frame
                for (int i = 0; i < tiffImage.PageCount; i++)
                {
                    // Set the active frame
                    tiffImage.ActiveFrame = tiffImage.Frames[i];

                    // Apply convolution filter with the edge detection kernel
                    tiffImage.Filter(tiffImage.Bounds, new ConvolutionFilterOptions(kernel));
                }

                // Save the processed multipage TIFF
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Source = new FileCreateSource(outputPath, false);
                tiffImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}