using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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

            string[] files = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
                }
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
 * 1. When a hospital IT team must convert thousands of DICOM radiology scans to PNG for integration with a web‑based viewer, they can use this code to automate the bulk conversion.
 * 2. When a research lab needs to extract image data from a folder of DICOM files and store them as lossless PNGs for machine‑learning preprocessing, this script provides a fast .NET solution.
 * 3. When a medical imaging vendor wants to generate thumbnail previews of patient studies by converting DICOM files to PNG on a scheduled server job, the program handles the directory creation and batch processing automatically.
 * 4. When a compliance auditor requires a portable, non‑proprietary copy of diagnostic images for archival, the code can bulk‑export DICOM files to PNG using Aspose.Imaging without manual intervention.
 * 5. When a developer is building a cross‑platform PowerShell automation that calls a .NET library to transform DICOM files into PNG for downstream reporting tools, this example shows the core conversion logic.
 */