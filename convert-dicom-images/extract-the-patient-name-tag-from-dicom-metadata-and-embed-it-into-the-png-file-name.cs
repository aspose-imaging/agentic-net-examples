using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.dcm";
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (var options = new PngOptions())
                {
                    image.Save(outputPath, options);
                }
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
 * 1. When a radiology department needs to convert DICOM scans to PNG images for web viewing while automatically naming each file with the patient’s name for easy identification.
 * 2. When a medical research team extracts patient name tags from DICOM metadata to generate PNG reports that can be sorted and searched by patient name in a file system.
 * 3. When a healthcare integration platform processes incoming DICOM files and creates PNG thumbnails whose filenames include the patient name to link images with electronic health records.
 * 4. When a hospital’s PACS migration script converts legacy DICOM images to PNG format and embeds the patient name in the filename to preserve traceability without a database lookup.
 * 5. When a telemedicine application prepares PNG snapshots of diagnostic images and needs the patient’s name in the file name to personalize the image before sending it to clinicians.
 */