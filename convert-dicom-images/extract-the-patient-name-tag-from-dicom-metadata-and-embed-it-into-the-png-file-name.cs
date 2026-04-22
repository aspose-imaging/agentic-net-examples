using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.dcm";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDirectory = "Output";
            Directory.CreateDirectory(outputDirectory);

            // Load DICOM image
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                // Use a default patient name (metadata extraction not supported in this version)
                string patientName = "Unknown";

                // Sanitize patient name for file name
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    patientName = patientName.Replace(c.ToString(), "_");
                }

                // Build output file path with patient name embedded
                string outputPath = Path.Combine(outputDirectory, $"Image_{patientName}.png");

                // Ensure output directory for the file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save as PNG
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