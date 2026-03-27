using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Set up input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (string inputPath in files)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path with .jpg extension
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG2000 image and save as JPEG with quality 80
            using (Jpeg2000Image jp2Image = new Jpeg2000Image(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions();
                jpegOptions.Quality = 80;
                jp2Image.Save(outputPath, jpegOptions);
            }
        }
    }
}