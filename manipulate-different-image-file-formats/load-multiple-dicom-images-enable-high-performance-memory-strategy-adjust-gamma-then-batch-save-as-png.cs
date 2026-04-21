using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Define input DICOM files (relative paths)
        string[] inputFiles = new string[]
        {
            "Input/image1.dcm",
            "Input/image2.dcm"
        };

        // Process each DICOM file
        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load DICOM image with high‑performance memory strategy
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Set a large buffer size hint for performance
                Aspose.Imaging.LoadOptions loadOptions = new Aspose.Imaging.LoadOptions();
                loadOptions.BufferSizeHint = 4 * 1024 * 1024; // 4 MB

                using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                {
                    // Adjust gamma (example value)
                    dicomImage.AdjustGamma(2.2f);

                    // Save each page as PNG
                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.Index}.png";
                        string outputPath = Path.Combine("Output", outputFileName);

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save page as PNG
                        page.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
    }
}