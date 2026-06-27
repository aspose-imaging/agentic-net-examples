using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input/sample.png";
            string outputPath = "output/sample.GaussianBlur.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image, apply Gaussian blur, and save
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                rasterImage.Save(outputPath);
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
 * 1. When a developer wants to automatically soften user‑uploaded PNG images stored in Azure Blob storage by applying a Gaussian blur filter via an Azure Function written in C# with Aspose.Imaging.
 * 2. When a SaaS platform needs to generate privacy‑preserving thumbnails for newly uploaded photos, using a serverless Azure Function to blur faces before saving the PNG output.
 * 3. When an e‑commerce site requires on‑the‑fly background smoothing for product images uploaded to Blob storage, leveraging Aspose.Imaging’s GaussianBlurFilterOptions in a C# Azure Function.
 * 4. When a content moderation pipeline must obscure sensitive details in images immediately after they are uploaded to Azure Blob, using a serverless function to apply a 5‑pixel radius blur and store the result as a .GaussianBlur.png file.
 * 5. When a mobile app backend wants to create stylized blurred previews of high‑resolution PNG assets uploaded to Azure, triggering an Azure Function that loads the image, applies a Gaussian blur, and saves the processed file back to Blob storage.
 */