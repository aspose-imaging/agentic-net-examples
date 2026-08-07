using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // Get all JPEG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.jpg");

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + "_resized.jpg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the JPEG image
                using (Image image = Image.Load(inputPath))
                {
                    // Determine scaling factor to keep the larger side at most 1200 pixels
                    int originalWidth = image.Width;
                    int originalHeight = image.Height;
                    int maxDimension = 1200;

                    double scale = 1.0;
                    if (originalWidth > originalHeight && originalWidth > maxDimension)
                    {
                        scale = (double)maxDimension / originalWidth;
                    }
                    else if (originalHeight >= originalWidth && originalHeight > maxDimension)
                    {
                        scale = (double)maxDimension / originalHeight;
                    }

                    int newWidth = (int)Math.Round(originalWidth * scale);
                    int newHeight = (int)Math.Round(originalHeight * scale);

                    // If the image is already within the size limit, just copy it
                    if (scale >= 1.0)
                    {
                        newWidth = originalWidth;
                        newHeight = originalHeight;
                    }

                    // Prepare resize settings with Lanczos algorithm
                    ImageResizeSettings resizeSettings = new ImageResizeSettings
                    {
                        Mode = ResizeType.LanczosResample
                    };

                    // Perform the resize
                    image.Resize(newWidth, newHeight, resizeSettings);

                    // Save the resized image as JPEG
                    JpegOptions saveOptions = new JpegOptions
                    {
                        Quality = 90 // reasonable quality
                    };
                    image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to batch‑resize product photos in JPEG format to a maximum of 1200 pixels for faster page loads on an e‑commerce website, they can use this C# Aspose.Imaging code with the Lanczos resampling algorithm.
 * 2. When a photo‑sharing app must automatically shrink user‑uploaded JPEG images to a 1200‑pixel limit before storing them in Azure Blob storage, the code provides a reliable C# solution for server‑side image processing.
 * 3. When a digital asset management system requires periodic optimization of legacy JPEG archives so that each image’s longest side does not exceed 1200 pixels, this Aspose.Imaging C# routine can be scheduled to run nightly.
 * 4. When a marketing automation tool needs to generate web‑ready versions of high‑resolution JPEG banners for email campaigns, the code resizes the collection to 1200 pixels using the high‑quality Lanczos filter.
 * 5. When a desktop utility must prepare a batch of JPEG screenshots for inclusion in a PDF report, ensuring that no image exceeds 1200 pixels while preserving detail, the provided C# Aspose.Imaging example handles the resizing efficiently.
 */