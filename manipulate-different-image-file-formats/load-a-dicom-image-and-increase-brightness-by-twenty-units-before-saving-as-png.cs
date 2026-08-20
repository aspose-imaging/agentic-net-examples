// HOW-TO: Increase DICOM Image Brightness by 20 and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Load the DICOM image, adjust brightness, and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;
                dicomImage.AdjustBrightness(20);
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
 * 1. When a radiology software needs to enhance the visibility of a DICOM scan before displaying it in a web portal, developers can use this code to brighten the image and convert it to PNG.
 * 2. When a medical research project requires batch processing of DICOM files to improve contrast for analysis, the snippet can be integrated to adjust brightness and store the results in a widely supported PNG format.
 * 3. When a healthcare mobile app must show patient scans with consistent lighting, developers can apply the brightness adjustment and PNG conversion to ensure the images render correctly on different devices.
 * 4. When an archival system needs to create thumbnail previews of DICOM images with higher brightness for quick visual inspection, this code provides a simple way to generate brighter PNG thumbnails.
 * 5. When a diagnostic AI pipeline expects input images in PNG with standardized brightness, the example can be used to preprocess DICOM files before feeding them into the model.
 */
