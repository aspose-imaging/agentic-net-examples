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
        string inputPath = @"C:\Images\input.wmf";
        string intermediatePath = @"C:\Images\temp.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (for final output)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (Image wmfImage = Image.Load(inputPath))
        {
            // Prepare rasterization options to convert WMF to raster format
            var rasterOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size
            };

            // Save the rasterized image to a temporary PNG file
            wmfImage.Save(intermediatePath, new PngOptions { VectorRasterizationOptions = rasterOptions });
        }

        // Ensure the directory for the intermediate file exists (already covered by output dir)
        // Load the temporary PNG as a raster image
        using (Image pngImage = Image.Load(intermediatePath))
        {
            var rasterImage = (RasterImage)pngImage;

            // Apply Gaussian blur filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image to the final output path
            rasterImage.Save(outputPath);
        }
    }
}