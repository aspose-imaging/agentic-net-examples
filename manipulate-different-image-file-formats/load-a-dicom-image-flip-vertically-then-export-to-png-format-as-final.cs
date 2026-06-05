using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output\\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image, flip vertically, and save as PNG
            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                image.Save(outputPath, new PngOptions());
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
 * 1. When a radiology software needs to convert patient DICOM scans to web‑friendly PNG thumbnails while correcting the orientation for display in a browser.
 * 2. When a healthcare integration pipeline must extract DICOM images, flip them vertically to match the viewer’s coordinate system, and store them as PNG files for electronic health record (EHR) archives.
 * 3. When a research application processes MRI DICOM datasets in C# using Aspose.Imaging, applies a vertical flip to align anatomical structures, and saves the results as PNG for inclusion in scientific publications.
 * 4. When a telemedicine platform automatically transforms uploaded DICOM X‑ray images into PNG format with a vertical flip to ensure consistent orientation across mobile devices.
 * 5. When a hospital’s batch‑processing script needs to read DICOM files, correct upside‑down images by rotating‑flipping, and generate PNG assets for use in patient portals or reporting tools.
 */