using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Set up base, input, and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add PSD files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all PSD files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.psd");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Load the PSD image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to RasterImage for deskew operation
                Aspose.Imaging.RasterImage raster = image as Aspose.Imaging.RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine($"Unable to process non-raster file: {inputPath}");
                    continue;
                }

                // Deskew the image without resizing, using a light gray background
                raster.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);

                // Prepare the output PNG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the deskewed image as PNG
                PngOptions pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
            }
        }
    }
}