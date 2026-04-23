using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "Input";
            string outputDir = "Output";

            // Ensure input directory exists; create if missing and exit
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDir, "*.dcm");

            foreach (string inputPath in dicomFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path (same name with .bmp extension)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".bmp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DICOM image
                using (DicomImage image = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    // Apply Gaussian blur filter to the whole image
                    image.Filter(
                        image.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Resize to 640x480 using nearest neighbour resampling
                    image.Resize(640, 480, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                    // Save as BMP
                    BmpOptions bmpOptions = new BmpOptions();
                    image.Save(outputPath, bmpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}