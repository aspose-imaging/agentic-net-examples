using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories (relative paths)
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Get all DICOM files in the input directory
        string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

        foreach (string inputPath in dicomFiles)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output file path with .tif extension
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".tif");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image, apply Otsu threshold, and save as TIFF
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;
                dicomImage.BinarizeOtsu();

                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    dicomImage.Save(outputPath, tiffOptions);
                }
            }
        }
    }
}