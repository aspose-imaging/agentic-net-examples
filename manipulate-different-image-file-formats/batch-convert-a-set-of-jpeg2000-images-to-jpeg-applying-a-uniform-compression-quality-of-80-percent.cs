using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

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

        foreach (var file in files)
        {
            // Process only JPEG2000 files
            string ext = Path.GetExtension(file).ToLowerInvariant();
            if (ext != ".jp2" && ext != ".j2k")
                continue;

            string inputPath = file;
            string outputPath = Path.Combine(outputDirectory, Path.ChangeExtension(Path.GetFileName(file), ".jpg"));

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG2000 image and save as JPEG with quality 80
            using (Jpeg2000Image jp2Image = new Jpeg2000Image(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    Quality = 80
                };
                jp2Image.Save(outputPath, jpegOptions);
            }
        }
    }
}