using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                using (var pngOptions = new PngOptions())
                {
                    dicomImage.Save(outputPath, pngOptions);
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
 * 1. When a C# radiology application uses Aspose.Imaging to load DICOM files and save them as 16‑bit PNG images for compatibility with third‑party analysis software.
 * 2. When a research team writes a C# batch‑processing script with Aspose.Imaging to convert large sets of DICOM scans into lossless PNGs for machine‑learning training pipelines.
 * 3. When a hospital information system needs to export patient CT or MRI images from DICOM to PNG via Aspose.Imaging so they can be viewed directly in standard web browsers.
 * 4. When a developer creates a diagnostic reporting tool in C# that extracts DICOM images with Aspose.Imaging and embeds the resulting high‑resolution PNGs into PDF reports.
 * 5. When a telemedicine platform uses Aspose.Imaging in a C# service to transform uploaded DICOM files into PNG format for fast preview and annotation on mobile devices.
 */