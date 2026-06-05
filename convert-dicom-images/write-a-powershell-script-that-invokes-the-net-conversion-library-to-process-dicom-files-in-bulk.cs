using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Batch directory setup (must be exactly as specified)
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

            // Process each DICOM file
            foreach (string filePath in files)
            {
                // Process only .dcm files
                if (!filePath.EndsWith(".dcm", StringComparison.OrdinalIgnoreCase))
                    continue;

                string inputPath = filePath;

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load DICOM image
                using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
                {
                    int pageIndex = 0;
                    foreach (var page in dicomImage.DicomPages)
                    {
                        // Construct output file path for each page
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{pageIndex}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save page as PNG
                        page.Save(outputPath, new PngOptions());

                        pageIndex++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}