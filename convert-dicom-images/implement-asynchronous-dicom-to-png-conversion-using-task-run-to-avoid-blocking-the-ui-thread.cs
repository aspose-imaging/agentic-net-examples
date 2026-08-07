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
        try
        {
            // Hardcoded input DICOM file and output directory
            string inputPath = @"C:\Temp\input.dcm";
            string outputDir = @"C:\Temp\Output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (DirectoryName may be null if outputDir ends with a file name)
            Directory.CreateDirectory(outputDir);

            // Run conversion on a background thread to avoid blocking UI
            await Task.Run(() => ConvertDicomToPng(inputPath, outputDir));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Synchronous conversion logic executed inside Task.Run
    private static void ConvertDicomToPng(string dicomPath, string outputDirectory)
    {
        // Open the DICOM file as a stream
        using (Stream stream = File.OpenRead(dicomPath))
        {
            // Load DICOM image with default load options
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                // Iterate through each page and save as PNG
                foreach (DicomPage page in dicomImage.DicomPages)
                {
                    // Build output file name: e.g., "input_page0.png"
                    string outputFileName = $"{Path.GetFileNameWithoutExtension(dicomPath)}_page{page.Index}.png";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    page.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a radiology desktop application needs to display DICOM scans as PNG thumbnails without freezing the user interface, developers can use this asynchronous conversion code.
 * 2. When a hospital’s PACS integration tool must batch‑convert incoming DICOM files to PNG for web‑based reporting while keeping the UI responsive, the Task.Run pattern is ideal.
 * 3. When a medical research portal allows clinicians to upload DICOM studies and instantly view them as PNG images in a C# WinForms dashboard, this non‑blocking conversion prevents UI lag.
 * 4. When a telemedicine mobile app processes DICOM images on a background thread to generate PNG snapshots for patient‑friendly viewing, the asynchronous approach ensures smooth interaction.
 * 5. When an imaging workflow automation script needs to convert DICOM slices to PNG for archival or machine‑learning preprocessing without blocking other UI operations, developers can employ this code.
 */