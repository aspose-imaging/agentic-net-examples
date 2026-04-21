using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Set up base, input, and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists; if not, create it and exit
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add DICOM files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (string inputPath in files)
        {
            // Process only DICOM files
            if (!Path.GetExtension(inputPath).Equals(".dcm", StringComparison.OrdinalIgnoreCase))
                continue;

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output TIFF path
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".tif";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure the output directory exists (unconditional call)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM, apply Otsu threshold, and save as TIFF
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;
                dicomImage.BinarizeOtsu();

                // Save using TIFF options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                dicomImage.Save(outputPath, tiffOptions);
            }
        }
    }
}