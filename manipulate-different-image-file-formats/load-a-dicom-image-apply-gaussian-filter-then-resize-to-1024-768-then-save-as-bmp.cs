using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image, apply Gaussian filter, resize, and save as BMP
            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                // Apply Gaussian blur filter to the whole image
                image.Filter(
                    new Aspose.Imaging.Rectangle(0, 0, image.Width, image.Height),
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Resize to 1024x768 using nearest neighbour resampling
                image.Resize(1024, 768, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                // Save as BMP
                var bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging application needs to convert DICOM scans into BMP thumbnails for quick preview in a web portal, applying a Gaussian blur to reduce noise and resizing to 1024×768 for consistent display.
 * 2. When a radiology research tool must preprocess DICOM images by smoothing them with a Gaussian filter and standardizing their dimensions before feeding them into a machine‑learning model that expects BMP input.
 * 3. When a hospital’s PACS integration requires exporting DICOM files as BMP files for legacy Windows‑based reporting software, using C# to load, denoise, and resize the images to fit the report layout.
 * 4. When a developer builds a desktop utility that batch‑processes DICOM ultrasound images, applying Gaussian blur to improve visual clarity and resizing them to 1024×768 before saving as BMP for archival purposes.
 * 5. When an e‑learning platform for medical students needs to generate high‑resolution BMP illustrations from DICOM scans, smoothing the images with a Gaussian filter and resizing them to a uniform 1024×768 size for consistent lesson content.
 */