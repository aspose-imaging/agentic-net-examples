using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ProgressManagement;

class Program
{
    static void Main(string[] args)
    {
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all CDR files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.cdr");

        foreach (string inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");

            // Ensure the directory for the output file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load options with progress reporting
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.ProgressEventHandler = info =>
            {
                Console.WriteLine($"Loading {fileName}: {info.EventType} {info.Value}/{info.MaxValue}");
            };

            // Load the CDR image
            using (CdrImage image = (CdrImage)Image.Load(inputPath, loadOptions))
            {
                // JPEG save options with progress reporting
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.Quality = 90;
                    jpegOptions.ProgressEventHandler = info =>
                    {
                        Console.WriteLine($"Saving {fileName}: {info.EventType} {info.Value}/{info.MaxValue}");
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
                }
            }

            Console.WriteLine($"Converted {fileName} to JPG.");
        }
    }
}