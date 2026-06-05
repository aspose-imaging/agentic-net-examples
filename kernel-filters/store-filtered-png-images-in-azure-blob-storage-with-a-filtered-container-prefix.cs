using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "filtered/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 2.0));

                PngOptions options = new PngOptions();
                options.FilterType = PngFilterType.Adaptive;

                raster.Save(outputPath, options);
            }

            // Placeholder for Azure Blob upload
            // UploadToAzureBlob(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static void UploadToAzureBlob(string filePath)
    {
        // Implementation would use Azure SDK to upload the file to a container named "filtered"
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to apply a Gaussian blur filter to user‑uploaded PNG files and then archive the processed images in Azure Blob Storage under a “filtered” container for later retrieval.
 * 2. When an e‑commerce platform wants to automatically de‑identify product photos by blurring sensitive details before storing the sanitized PNGs in a secure Azure Blob container named “filtered”.
 * 3. When a medical imaging system must preprocess PNG scans with adaptive PNG filtering and Gaussian blur, then upload the cleaned images to Azure Blob Storage with a “filtered” prefix to separate them from raw data.
 * 4. When a content‑management workflow requires batch processing of PNG assets, applying a blur effect and saving them with adaptive PNG compression before pushing the results to an Azure Blob “filtered” container for downstream publishing.
 * 5. When a mobile app backend needs to generate blurred preview PNGs for privacy compliance and store those previews in Azure Blob Storage using the “filtered” container to keep them distinct from original uploads.
 */