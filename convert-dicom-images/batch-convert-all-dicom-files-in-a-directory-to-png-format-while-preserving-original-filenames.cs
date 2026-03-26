using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Define base, input, and output directories
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

        // Get all DICOM files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*")
            .Where(f => f.EndsWith(".dcm", StringComparison.OrdinalIgnoreCase))
            .ToArray();

        foreach (var filePath in files)
        {
            // Verify the input file exists
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            // Preserve original filename for the PNG output
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

            // Ensure the output directory exists before saving
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (DicomImage dicom = (DicomImage)Image.Load(filePath))
            {
                // Handle multi‑page DICOM files
                if (dicom.DicomPages != null && dicom.DicomPages.Count() > 1)
                {
                    foreach (var page in dicom.DicomPages)
                    {
                        string pageOutputPath = Path.Combine(outputDirectory,
                            $"{fileNameWithoutExt}_page{page.Index}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(pageOutputPath));
                        using (var pngOptions = new PngOptions())
                        {
                            page.Save(pageOutputPath, pngOptions);
                        }
                    }
                }
                else
                {
                    // Single‑page DICOM: save directly as PNG
                    using (var pngOptions = new PngOptions())
                    {
                        dicom.Save(outputPath, pngOptions);
                    }
                }
            }
        }
    }
}