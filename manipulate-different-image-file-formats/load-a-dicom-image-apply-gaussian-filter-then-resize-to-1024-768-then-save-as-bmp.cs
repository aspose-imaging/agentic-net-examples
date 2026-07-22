using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Bmp;

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

            // Load DICOM image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Apply Gaussian blur filter to the whole image
                dicomImage.Filter(
                    dicomImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Resize to 1024x768 using nearest neighbour resampling
                dicomImage.Resize(1024, 768, ResizeType.NearestNeighbourResample);

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
 * 1. When a medical imaging application needs to convert a DICOM scan into a BMP thumbnail with reduced noise for quick preview in a web portal.
 * 2. When a radiology workflow requires applying a Gaussian blur to a DICOM image to anonymize patient details before resizing it to a standard 1024×768 display.
 * 3. When a desktop C# tool must batch‑process DICOM files, smooth them with a Gaussian filter, resize them to a uniform resolution, and save them as BMP for compatibility with legacy imaging software.
 * 4. When a healthcare data‑export service needs to transform high‑resolution DICOM images into BMP format while applying a blur to reduce file size and then scaling them for inclusion in PDF reports.
 * 5. When a diagnostic imaging system wants to load a DICOM image, enhance it with a Gaussian blur, resize it to a common screen size, and store the result as BMP for use in a Windows Forms viewer.
 */