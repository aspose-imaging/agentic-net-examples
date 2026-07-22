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
        string inputPath = @"C:\temp\sample.dicom";
        string outputPath = @"C:\temp\sample.Crop.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage for DICOM-specific operations
                DicomImage dicomImage = (DicomImage)image;

                // Crop by shifts: left 10, right 10, top 20, bottom 20 pixels
                dicomImage.Crop(10, 10, 20, 20);

                // Save the cropped image as PNG
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
 * 1. When a medical imaging application needs to extract a region of interest from a DICOM X‑ray and deliver it as a PNG thumbnail for quick review in a web portal.
 * 2. When a radiology workflow requires removing peripheral artifacts from a DICOM CT slice by cropping 10 px left/right and 20 px top/bottom before archiving the image as a PNG for reporting.
 * 3. When a healthcare data integration service converts DICOM scans to PNG format and trims unnecessary borders to reduce file size for electronic health record (EHR) display.
 * 4. When a research tool processes DICOM MRI images, crops a consistent pixel margin, and saves the result as PNG for inclusion in scientific publications or presentations.
 * 5. When a telemedicine platform automatically loads patient DICOM files, crops a fixed pixel offset to focus on the diagnostic area, and outputs PNG images for mobile device viewing.
 */