using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure input and output directories exist
        Directory.CreateDirectory(inputDirectory);
        Directory.CreateDirectory(outputDirectory);

        // Get all DNG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.dng");

        foreach (string inputPath in files)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tif");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DNG image, resize, and save as TIFF
            using (Image image = Image.Load(inputPath))
            {
                var dngImage = (Aspose.Imaging.FileFormats.Dng.DngImage)image;

                // Resize to 1024x768 using nearest neighbour resampling
                dngImage.Resize(1024, 768, ResizeType.NearestNeighbourResample);

                // Save as TIFF with default options
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    dngImage.Save(outputPath, tiffOptions);
                }
            }
        }
    }
}