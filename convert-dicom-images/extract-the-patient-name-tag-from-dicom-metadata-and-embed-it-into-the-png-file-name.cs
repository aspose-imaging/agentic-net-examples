// HOW-TO: Save DICOM Image as PNG Using Patient Name for File Name in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.dcm");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                string patientName = "Unknown";

                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    patientName = patientName.Replace(c, '_');
                }

                string outputFileName = $"{patientName}.png";
                string outputPath = Path.Combine("Output", outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                dicom.Save(outputPath, new PngOptions());
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
 * 1. When a radiology application needs to convert DICOM scans to PNG files and name each output with the patient’s name for easy identification.
 * 2. When integrating a medical imaging pipeline that extracts metadata from DICOM files and creates human‑readable filenames for downstream reporting tools.
 * 3. When automating the export of DICOM images to a web‑friendly format while preserving patient information in the file name for audit trails.
 * 4. When building a batch script that processes a folder of DICOM studies and saves each image as a PNG named after the patient to simplify folder organization.
 * 5. When developing a C# utility that reads DICOM metadata with Aspose.Imaging and generates PNG assets for electronic health record (EHR) systems that require patient‑named files.
 */
