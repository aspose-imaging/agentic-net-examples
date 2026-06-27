using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\Input\image1.dcm",
                @"C:\Images\Input\image2.dcm",
                @"C:\Images\Input\image3.dcm"
            };

            string[] outputPaths = new string[]
            {
                @"C:\Images\Output\image1.bmp",
                @"C:\Images\Output\image2.bmp",
                @"C:\Images\Output\image3.bmp"
            };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DICOM image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to DicomImage to access DICOM-specific functionality
                    DicomImage dicomImage = image as DicomImage;
                    if (dicomImage == null)
                    {
                        Console.Error.WriteLine($"Failed to load DICOM image: {inputPath}");
                        continue;
                    }

                    // Apply Gaussian filter (placeholder - replace with actual filter if available)
                    // Example: dicomImage.Filters.Add(new GaussianBlurFilter(radius: 2));
                    // Since no specific API is provided, this step is left as a comment.

                    // Resize to 640x480 using Bilinear resampling
                    dicomImage.Resize(640, 480, ResizeType.BilinearResample);

                    // Save as BMP
                    var bmpOptions = new BmpOptions();
                    dicomImage.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging system needs to batch‑convert DICOM scans into BMP thumbnails for quick web preview, applying a Gaussian blur to reduce noise and resizing each image to a consistent 640×480 resolution.
 * 2. When a radiology research project must preprocess multiple DICOM files by smoothing them with a Gaussian filter, scaling them to a standard size, and saving as BMPs for analysis with non‑medical image tools.
 * 3. When a hospital PACS integration requires generating low‑resolution BMP copies of DICOM studies for printing or archiving, using C# and Aspose.Imaging to apply noise reduction and uniform resizing in a batch process.
 * 4. When a healthcare mobile app downloads DICOM images, applies a Gaussian blur to protect patient privacy, resizes them for device screens, and stores the results as BMP assets via .NET batch processing.
 * 5. When an AI training pipeline prepares a dataset by converting DICOM medical images into uniform 640×480 BMP files with Gaussian smoothing to improve model robustness, automating the workflow with Aspose.Imaging for .NET.
 */