using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input and output directories (relative paths)
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Get all DNG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.dng");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine the output TIFF path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".tif");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DngImage for raw image operations
                DngImage dng = (DngImage)image;

                // Resize to 1024x768 using nearest neighbour resampling
                dng.Resize(1024, 768, ResizeType.NearestNeighbourResample);

                // Prepare TIFF save options
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    // Save the resized image as TIFF
                    dng.Save(outputPath, tiffOptions);
                }
            }
        }
    }
}