using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DICOM files
        string[] inputPaths = new string[]
        {
            @"C:\Images\Input1.dcm",
            @"C:\Images\Input2.dcm"
        };

        // Output directory for PNG files
        string outputDir = @"C:\Images\Output";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(outputDir);

        foreach (string inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Set up load options with a small buffer size hint for high‑performance memory usage
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 256 * 1024 // 256 KB
            };

            // Load the DICOM image from a file stream using the load options
            using (FileStream stream = File.OpenRead(inputPath))
            using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
            {
                // Adjust gamma for the whole DICOM image (example gamma value)
                dicomImage.AdjustGamma(2.2f);

                // Iterate through each page and save as PNG
                foreach (DicomPage page in dicomImage.DicomPages)
                {
                    // Build output file name: InputFileName_page{Index}.png
                    string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.Index}.png";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Ensure the directory for the output file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    page.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}