using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image, apply Gaussian blur, and save
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save as JPEG
                JpegOptions options = new JpegOptions();
                raster.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to automatically blur user‑uploaded PNG photos stored in Azure Blob storage via an Azure Function trigger to protect privacy before publishing them as JPEGs.
 * 2. When an e‑commerce site wants to generate soft‑focused preview images by applying a Gaussian blur to high‑resolution PNG uploads and saving the results as compressed JPEG thumbnails.
 * 3. When a document management system must preprocess scanned PNG documents with a Gaussian blur to reduce noise before sending them to an OCR service, using a C# Azure Function.
 * 4. When a marketing automation workflow requires creating stylized banner images by blurring background PNG assets and converting them to JPEG format for email campaigns.
 * 5. When a mobile app backend needs to produce low‑contrast, consistent thumbnails for user‑generated content stored in Azure Blob storage by applying a Gaussian blur filter in an Azure Function and outputting JPEG files.
 */