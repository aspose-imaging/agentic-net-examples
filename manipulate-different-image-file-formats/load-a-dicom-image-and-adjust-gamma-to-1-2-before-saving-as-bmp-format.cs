using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.dicom";
        string outputPath = @"C:\Images\sample_adjusted.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Adjust gamma for all channels (value 1.2)
                dicomImage.AdjustGamma(1.2f);

                // Save the result as BMP
                dicomImage.Save(outputPath, new BmpOptions());
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
 * 1. When a radiology software needs to export DICOM X‑ray images to BMP format for integration with legacy Windows viewers and wants to boost image brightness by applying a gamma of 1.2.
 * 2. When a healthcare data pipeline must preprocess DICOM CT scans by adjusting gamma before saving them as BMP files for use in machine‑learning models that expect standard bitmap inputs.
 * 3. When a hospital’s PACS system requires converting DICOM ultrasound images to BMP thumbnails with consistent gamma correction to ensure uniform visual quality across different monitors.
 * 4. When a C# desktop application needs to load a DICOM MRI slice, enhance its contrast with a 1.2 gamma adjustment, and store the result as a BMP for inclusion in patient reports.
 * 5. When a developer is building a cross‑platform imaging tool that reads DICOM files, applies gamma correction to improve visibility, and saves the output as BMP to be displayed in non‑medical image viewers.
 */