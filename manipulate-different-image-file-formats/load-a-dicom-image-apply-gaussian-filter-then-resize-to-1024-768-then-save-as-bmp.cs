using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DicomImage dicomImage = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Apply Gaussian blur filter to the entire image
                dicomImage.Filter(dicomImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Resize to 1024x768 using Lanczos resampling
                dicomImage.Resize(1024, 768, Aspose.Imaging.ResizeType.LanczosResample);

                // Save as BMP
                BmpOptions bmpOptions = new BmpOptions();
                dicomImage.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging application needs to convert DICOM scans to BMP for display on legacy Windows systems while applying a Gaussian blur to reduce noise and resizing to fit a 1024×768 viewport.
 * 2. When a radiology research tool must preprocess DICOM images by smoothing them, standardizing their dimensions, and exporting them as BMP files for integration with third‑party analysis software that only accepts BMP.
 * 3. When a healthcare data pipeline requires automated batch processing of DICOM files to generate thumbnail BMP images of 1024×768 with a Gaussian blur to protect patient privacy before uploading to a web portal.
 * 4. When a diagnostic workstation needs to load a DICOM image, enhance it with a Gaussian filter, resize it for presentation on a 1024×768 monitor, and save it as BMP for use in printed reports.
 * 5. When a C#‑based telemedicine platform must transform incoming DICOM scans into BMP format, applying a blur to smooth artifacts and resizing to a standard resolution for consistent viewing across different client devices.
 */