using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output directories (relative paths)
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all CDR files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.cdr", SearchOption.TopDirectoryOnly);

        foreach (string inputPath in files)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output file path (same name, .jpg extension)
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CDR image with load progress reporting
            using (CdrImage image = (CdrImage)Image.Load(
                inputPath,
                new CdrLoadOptions
                {
                    ProgressEventHandler = (Aspose.Imaging.ProgressManagement.ProgressEventHandlerInfo info) =>
                    {
                        Console.WriteLine($"Load {info.EventType} : {info.Value}/{info.MaxValue}");
                    }
                }))
            {
                // Configure JPEG options with save progress reporting
                var jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ProgressEventHandler = (Aspose.Imaging.ProgressManagement.ProgressEventHandlerInfo info) =>
                    {
                        Console.WriteLine($"Save {info.EventType} : {info.Value}/{info.MaxValue}");
                    }
                };

                // Save the image as JPEG
                image.Save(jpegOptions);
            }
        }
    }
}