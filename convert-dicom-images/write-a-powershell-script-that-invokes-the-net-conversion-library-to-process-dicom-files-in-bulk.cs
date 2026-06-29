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
            // Set up base, input, and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists; create if missing and exit
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

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                // Process only DICOM files
                if (!string.Equals(Path.GetExtension(inputPath), ".dcm", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_gray.dcm";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DICOM image and save with grayscale color type
                using (Image image = Image.Load(inputPath))
                {
                    var options = new DicomOptions { ColorType = ColorType.Grayscale8Bit };
                    image.Save(outputPath, options);
                }

                Console.WriteLine($"Processed: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a hospital IT team needs to convert a large batch of DICOM scans to grayscale for anonymized research archives using Aspose.Imaging in a .NET application.
 * 2. When a radiology software developer wants to automate the processing of incoming .dcm files in a folder, applying image transformations and saving the results to an output directory.
 * 3. When a medical imaging startup must ensure that all DICOM files in a directory are validated, exist, and are converted to a standardized format before uploading to a cloud PACS system.
 * 4. When a QA engineer needs to test the bulk handling of DICOM files, verifying that the program skips non‑DICOM extensions and creates the required input and output folders automatically.
 * 5. When a data scientist requires a simple C# script to iterate over a collection of DICOM images, generate grayscale versions, and store them with a consistent naming convention for downstream analysis.
 */