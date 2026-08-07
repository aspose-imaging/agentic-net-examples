using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output\\filtered.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply median filter with size 5 to the whole image
                dicomImage.Filter(dicomImage.Bounds, new MedianFilterOptions(5));

                // Save the filtered image as PNG
                dicomImage.Save(outputPath, new PngOptions());
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
 * 1. When a radiology web portal needs to reduce speckle noise in a DICOM X‑ray image before creating a PNG thumbnail for fast browser display.
 * 2. When a medical research workflow must preprocess noisy CT scan DICOM files with a median filter to improve visual clarity before archiving them as lossless PNGs.
 * 3. When a hospital PACS integration project requires converting DICOM ultrasound frames to PNG for inclusion in patient reports, applying a median filter to enhance image quality.
 * 4. When a diagnostic AI model expects clean PNG inputs, developers can apply a median filter to the original DICOM MRI slices and save the results as PNGs for training data.
 * 5. When a mobile health app needs to display DICOM dental images on iOS or Android, the backend can filter the DICOM with a median filter and export a PNG for fast rendering.
 */