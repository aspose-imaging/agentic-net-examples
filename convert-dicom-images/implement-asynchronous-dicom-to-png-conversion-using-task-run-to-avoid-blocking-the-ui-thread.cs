using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory) ?? outputDirectory);

            // Perform conversion on a background thread
            await Task.Run(() =>
            {
                // Open the DICOM file as a stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Load the DICOM image from the stream
                    using (DicomImage dicomImage = new DicomImage(stream))
                    {
                        // Iterate through each page and save as PNG
                        foreach (DicomPage dicomPage in dicomImage.DicomPages)
                        {
                            string outputPath = Path.Combine(outputDirectory, $"page_{dicomPage.Index}.png");
                            // Save the page as PNG using Aspose.Imaging PNG options
                            dicomPage.Save(outputPath, new PngOptions());
                        }
                    }
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging desktop app must show DICOM scans in a Windows Forms UI without freezing the interface, developers can use this asynchronous conversion to PNG on a background thread.
 * 2. When a radiology web service needs to generate thumbnail previews of multi‑frame DICOM studies for a web portal, the code can convert each DICOM page to PNG without blocking other requests.
 * 3. When a batch processing tool has to archive DICOM files as lossless PNGs for long‑term storage while keeping the UI responsive, this pattern enables non‑blocking conversion.
 * 4. When a diagnostic desktop application integrates with third‑party image viewers that only support PNG, developers can asynchronously transform incoming DICOM streams into PNG files.
 * 5. When a hospital’s data‑migration script moves patient imaging data from DICOM to a cloud‑based PNG repository and must avoid blocking other operations, the Task.Run approach provides safe parallel conversion.
 */