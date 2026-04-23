using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input\\sample.cdr";
        string outputPath = "output\\result.bmp";

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

            // Load the CorelDRAW (CDR) file
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Save the CDR image to a memory stream as BMP
                using (MemoryStream ms = new MemoryStream())
                {
                    cdrImage.Save(ms, new BmpOptions());
                    ms.Position = 0; // Reset stream position for reading

                    // Load the BMP from the memory stream as a raster image
                    using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                    {
                        // Apply Gaussian blur filter to the entire image
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Save the processed image to the final BMP file
                        rasterImage.Save(outputPath, new BmpOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Output any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}