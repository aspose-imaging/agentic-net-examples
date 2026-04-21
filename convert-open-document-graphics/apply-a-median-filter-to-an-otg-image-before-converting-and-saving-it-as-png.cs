using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary PNG path for intermediate rasterization
        string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

        // Load the OTG image and rasterize it to PNG
        using (Image otgImage = Image.Load(inputPath))
        {
            // Set up rasterization options to match the original size
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };

            // PNG save options with vector rasterization
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = otgRasterOptions
            };

            // Save the rasterized image to a temporary PNG file
            otgImage.Save(tempPngPath, pngOptions);
        }

        // Load the temporary PNG as a raster image, apply median filter, and save final PNG
        using (Image pngImage = Image.Load(tempPngPath))
        {
            var rasterImage = (RasterImage)pngImage;

            // Apply median filter with a kernel size of 5 to the entire image
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

            // Save the filtered image to the final output path
            rasterImage.Save(outputPath);
        }

        // Optionally delete the temporary file
        try
        {
            File.Delete(tempPngPath);
        }
        catch
        {
            // Ignore any errors during cleanup
        }
    }
}