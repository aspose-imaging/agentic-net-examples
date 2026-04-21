using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Define base, input and output directories relative to the current directory
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists; if not, create it and exit
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all EMF files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.emf");

        foreach (var inputPath in files)
        {
            // Verify the input file exists (safety check)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Build the output JPEG file path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with progressive encoding
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.CompressionType = JpegCompressionMode.Progressive;
                    jpegOptions.Quality = 90; // Adjust quality as needed

                    // Save the image as JPEG
                    image.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}