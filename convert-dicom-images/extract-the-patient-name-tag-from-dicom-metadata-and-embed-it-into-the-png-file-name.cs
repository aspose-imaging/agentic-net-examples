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
        string inputPath = "Input\\sample.dcm";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Attempt to extract Patient Name from metadata via reflection
            string patientName = "UnknownPatient";
            var metadata = dicomImage.Metadata;
            if (metadata != null)
            {
                var prop = metadata.GetType().GetProperty("PatientName");
                if (prop != null)
                {
                    var value = prop.GetValue(metadata) as string;
                    if (!string.IsNullOrEmpty(value))
                    {
                        patientName = value;
                    }
                }
            }

            // Prepare output path with patient name embedded
            string outputFileName = $"{patientName}.png";
            string outputPath = Path.Combine("Output", outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save DICOM image as PNG
            dicomImage.Save(outputPath, new PngOptions());
        }
    }
}