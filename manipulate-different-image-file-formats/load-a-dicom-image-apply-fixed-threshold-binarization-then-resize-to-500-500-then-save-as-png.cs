using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"input.dcm";
        string outputPath = @"output\result.png";

        try
        {
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

                // Apply fixed threshold binarization (threshold value 127)
                dicomImage.BinarizeFixed(127);

                // Resize to 500x500 using Bilinear resampling (any ResizeType can be used)
                dicomImage.Resize(500, 500, ResizeType.BilinearResample);

                // Save as PNG
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
 * 1. When a medical imaging application needs to convert a DICOM X‑ray scan into a high‑contrast 500×500 PNG thumbnail for quick preview in a web portal.
 * 2. When a radiology workflow requires batch processing of DICOM images to produce binary masks that can be overlaid on reports, using fixed threshold binarization and resizing for consistent layout.
 * 3. When a machine‑learning pipeline expects PNG input, a developer can load DICOM scans, apply a 127 threshold to create binary images, resize them to 500×500, and save them for model training.
 * 4. When a hospital’s PACS integration must generate low‑resolution PNG snapshots of DICOM studies for mobile devices, the code performs binarization and scaling in C#.
 * 5. When a research tool needs to extract DICOM image data, convert it to a PNG format, and standardize the size for inclusion in publications or presentations.
 */