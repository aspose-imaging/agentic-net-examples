// HOW-TO: Batch Crop Rotate and Resize Images in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            string[] files = Directory.GetFiles(inputDir);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDir, fileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Crop 10 pixels from each side
                    image.Crop(10, 10, 10, 10);

                    // Rotate 90 degrees
                    image.Rotate(90f);

                    // Resize to 800x600
                    image.Resize(800, 600);

                    // Save the processed image
                    image.Save(outputPath);
                }
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
 * 1. When you need to automatically prepare a large set of product photos by trimming borders, rotating them to portrait orientation, and resizing them to web‑friendly dimensions before uploading to an e‑commerce site.
 * 2. When you must preprocess scanned documents stored as TIFF files, removing unwanted margins, aligning the pages, and scaling them to a standard size for OCR or archival storage.
 * 3. When a photo‑gallery application requires generating uniform thumbnails from mixed‑format images (JPEG, PNG, BMP) by cropping edges, rotating, and resizing them in a single batch operation.
 * 4. When a batch of user‑submitted images needs to be normalized to 800×600 pixels with consistent orientation and trimmed edges before being fed into a machine‑learning model for image classification.
 * 5. When you are migrating legacy image assets and want to apply the same cropping, rotation, and resizing rules to every file in a folder, saving the transformed copies to a separate output directory.
 */
