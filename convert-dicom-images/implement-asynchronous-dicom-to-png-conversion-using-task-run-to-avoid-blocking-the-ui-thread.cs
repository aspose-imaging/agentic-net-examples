using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.dicom";
        string outputPath = "Output/sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Perform conversion on a background thread
        Task conversionTask = Task.Run(() =>
        {
            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage for DICOM-specific operations
                using (DicomImage dicom = (DicomImage)image)
                {
                    // Save as PNG using PngOptions
                    dicom.Save(outputPath, new PngOptions());
                }
            }
        });

        // Wait for the conversion to complete
        conversionTask.Wait();
    }
}