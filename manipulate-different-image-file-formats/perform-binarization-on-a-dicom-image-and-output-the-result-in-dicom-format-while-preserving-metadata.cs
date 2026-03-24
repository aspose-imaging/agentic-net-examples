using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.dcm";
        string outputPath = "output.dcm";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM-specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Binarize the image using a fixed threshold (e.g., 127)
            dicomImage.BinarizeFixed(127);

            // Prepare DICOM save options and preserve original metadata
            var options = new DicomOptions
            {
                KeepMetadata = true
            };

            // Save the binarized image back to DICOM format
            dicomImage.Save(outputPath, options);
        }
    }
}