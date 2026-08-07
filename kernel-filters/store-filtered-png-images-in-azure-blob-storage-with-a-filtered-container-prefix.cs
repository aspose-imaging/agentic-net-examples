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

            // Load the PNG image
            using (PngImage pngImage = (PngImage)Image.Load(inputPath))
            {
                // Configure PNG save options with a filter type (e.g., Adaptive)
                PngOptions saveOptions = new PngOptions
                {
                    FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive,
                    // Additional options can be set here if needed
                };

                // Save the filtered image to the output path
                pngImage.Save(outputPath, saveOptions);
            }

            // Placeholder: Upload the file at outputPath to Azure Blob Storage
            // using Azure REST API or SDK (not included due to library restrictions)
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to reduce the file size of PNG assets before uploading them to Azure Blob Storage for a web‑site CDN, they can use this code to apply an adaptive PNG filter and store the optimized image in a “filtered” container.
 * 2. When an e‑commerce platform must preprocess product photos in C# to ensure consistent PNG compression before archiving them in Azure Blob Storage, this snippet creates the filtered output folder and saves the image with Aspose.Imaging’s filter options.
 * 3. When a medical imaging application wants to apply a loss‑less PNG filter to scanned documents and then push the filtered files to Azure Blob Storage for secure cloud backup, the code demonstrates the required file‑existence check, directory creation, and saving with Aspose.Imaging.
 * 4. When a DevOps pipeline automates the preparation of PNG icons by applying an adaptive filter and storing them under a “filtered” prefix in Azure Blob Storage, this example shows how to perform the operation programmatically in .NET.
 * 5. When a content‑management system needs to validate that a source PNG exists, apply a specific PNG filter using Aspose.Imaging, and then upload the filtered version to Azure Blob Storage for later retrieval, this code provides the essential steps.
 */