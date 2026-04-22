using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Base directory of the application
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input folder exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output folder exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all CDR files in the input folder
            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (var inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build output JPEG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                // Ensure the output directory exists (handles possible subfolders)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CDR image with progress reporting
                using (var image = Image.Load(inputPath, new LoadOptions
                {
                    ProgressEventHandler = delegate (Aspose.Imaging.ProgressManagement.ProgressEventHandlerInfo info)
                    {
                        Console.WriteLine($"Load {info.EventType} : {info.Value}/{info.MaxValue}");
                    }
                }))
                {
                    // Configure JPEG options with progress reporting
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 90,
                        ProgressEventHandler = delegate (Aspose.Imaging.ProgressManagement.ProgressEventHandlerInfo info)
                        {
                            Console.WriteLine($"Save {info.EventType} : {info.Value}/{info.MaxValue}");
                        }
                    };

                    // Save the image as JPEG
                    image.Save(outputPath, jpegOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}