// HOW-TO: Apply Gaussian Blur to PNG and Upload to Azure Blob in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = Path.Combine("filtered", "output.png");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur filter (radius 5, sigma 4.0)
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0);
                raster.Filter(raster.Bounds, filterOptions);

                // Prepare PNG save options
                PngOptions saveOptions = new PngOptions
                {
                    // Use adaptive filtering for better compression
                    FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive
                };

                // Save the filtered image
                raster.Save(outputPath, saveOptions);
            }

            // Placeholder for Azure Blob Storage upload
            throw new NotSupportedException("Azure Blob Storage upload not implemented.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically blur sensitive areas of a PNG image before storing it in an Azure Blob container.
 * 2. When you want to preprocess product photos with a Gaussian blur and save the compressed PNGs to a “filtered” folder for later cloud upload.
 * 3. When a web service must generate blurred PNG thumbnails, apply adaptive PNG filtering for better compression, and prepare them for Azure Blob storage.
 * 4. When a batch job processes incoming PNG files, applies a Gaussian blur filter, and saves the results in a specific directory ready for Azure Blob transfer.
 * 5. When you are building a CI pipeline that validates image transformations by blurring PNGs and ensures the output can be uploaded to an Azure Blob container.
 */
