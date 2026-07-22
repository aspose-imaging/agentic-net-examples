using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.dicom";
        string outputPath = @"C:\Images\sample_brightness20.png";

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

                // Increase brightness by 20 units (range -255 to 255)
                dicomImage.AdjustBrightness(20);

                // Save the adjusted image as PNG
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
 * 1. When a radiology software needs to convert a DICOM scan to a PNG thumbnail with enhanced visibility for a web portal, a developer can use this code to load the DICOM, boost brightness by 20, and save the result as PNG.
 * 2. When a medical research team wants to preprocess DICOM images for machine‑learning pipelines that require PNG inputs with consistent lighting, this snippet adjusts the brightness and outputs the required format.
 * 3. When a hospital’s PACS integration needs to generate patient‑friendly PNG snapshots from DICOM files for inclusion in electronic health records, the code provides a quick way to brighten and export the images.
 * 4. When a mobile health app must display diagnostic images with better contrast on low‑resolution screens, a developer can employ this routine to increase brightness and convert the DICOM to a PNG that the app can render.
 * 5. When an automated reporting tool extracts DICOM images, applies a uniform brightness correction, and stores them as PNG files for archival or printing, this example shows the exact C# steps to achieve it.
 */