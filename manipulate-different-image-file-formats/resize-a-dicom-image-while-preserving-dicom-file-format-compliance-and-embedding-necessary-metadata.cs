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
        string outputPath = "output_resized.dcm";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage for DICOM-specific operations
            DicomImage dicomImage = image as DicomImage;
            if (dicomImage == null)
            {
                Console.Error.WriteLine("The loaded file is not a DICOM image.");
                return;
            }

            // Define new dimensions (example: reduce size by 50%)
            int newWidth = dicomImage.Width / 2;
            int newHeight = dicomImage.Height / 2;

            // Resize the image using Bilinear resampling
            dicomImage.Resize(newWidth, newHeight, ResizeType.BilinearResample);

            // Prepare DICOM save options and preserve original metadata
            var saveOptions = new DicomOptions
            {
                KeepMetadata = true
            };

            // Save the resized image back to DICOM format
            dicomImage.Save(outputPath, saveOptions);
        }
    }
}