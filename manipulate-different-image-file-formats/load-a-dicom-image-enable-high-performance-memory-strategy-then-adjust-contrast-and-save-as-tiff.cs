using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.tif";

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

            // Configure high‑performance memory strategy
            var loadOptions = new Aspose.Imaging.LoadOptions
            {
                BufferSizeHint = 256 * 1024 // 256 KB buffer size hint
            };

            // Load DICOM image using a stream and the load options
            using (var stream = File.OpenRead(inputPath))
            using (var dicomImage = new DicomImage(stream, loadOptions))
            {
                // Adjust contrast (value in range [-100, 100])
                dicomImage.AdjustContrast(50f);

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the adjusted image as TIFF
                dicomImage.Save(outputPath, tiffOptions);
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
 * 1. When a medical imaging application needs to convert DICOM scans to TIFF files for archival while applying a contrast boost and minimizing memory usage with Aspose.Imaging’s high‑performance buffer strategy.
 * 2. When a radiology workflow requires batch processing of DICOM images to enhance visibility for diagnostic review and then store the results as lossless TIFFs using C# and Aspose.Imaging.
 * 3. When a healthcare integration service must read DICOM files from a stream, adjust the image contrast for better display on web portals, and save the output as TIFF without loading the entire file into memory.
 * 4. When a PACS (Picture Archiving and Communication System) developer wants to ensure fast loading of large DICOM datasets by configuring BufferSizeHint and then export the processed images to TIFF for compatibility with third‑party viewers.
 * 5. When a C# developer is building a diagnostic reporting tool that needs to programmatically improve DICOM image contrast and generate TIFF files for inclusion in PDF reports while controlling memory consumption.
 */