using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure input directory exists
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

        // Get all DICOM files in the input directory
        string[] inputFiles = Directory.GetFiles(inputDirectory, "*.dcm");

        foreach (string inputPath in inputFiles)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".bmp");

            // Ensure output directory exists for this file
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Process the DICOM image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var dicomImage = (DicomImage)image;

                // Apply Gaussian blur filter to the whole image
                dicomImage.Filter(
                    dicomImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Resize to 640x480 using nearest neighbour resampling
                dicomImage.Resize(640, 480, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                // Save as BMP
                var bmpOptions = new BmpOptions();
                dicomImage.Save(outputPath, bmpOptions);
            }
        }
    }
}