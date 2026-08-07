using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.png";

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
            using (Image dicomImage = Image.Load(inputPath))
            {
                // Set PNG options with Truecolor to preserve full color information
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.Truecolor
                };

                // Save as PNG using the specified options
                dicomImage.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging system needs to export DICOM scans as high‑fidelity PNG files for patient reports, using truecolor PNG preserves the full color depth and diagnostic detail.
 * 2. When a radiology research pipeline converts DICOM images to PNG for machine‑learning preprocessing, truecolor ensures the original pixel values remain intact for accurate model training.
 * 3. When a hospital PACS integration generates PNG thumbnails for a web portal, setting the PNG color type to truecolor retains the subtle grayscale or color nuances of the source DICOM.
 * 4. When a telemedicine platform shares DICOM images with external specialists via email, converting them to truecolor PNG provides a universally viewable format without losing visual information.
 * 5. When a healthcare mobile app downloads DICOM files and saves them locally as PNG for offline viewing, truecolor PNG guarantees the on‑device viewer displays the image with the same color fidelity as the original DICOM.
 */