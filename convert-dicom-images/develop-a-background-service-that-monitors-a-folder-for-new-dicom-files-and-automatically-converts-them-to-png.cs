using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Hardcoded input and output directories
    private static readonly string inputFolder = @"C:\DicomInput";
    private static readonly string outputFolder = @"C:\PngOutput";

    static void Main()
    {
        try
        {
            // Ensure output base directory exists
            Directory.CreateDirectory(outputFolder);

            // Set up a watcher for new DICOM files
            var watcher = new FileSystemWatcher(inputFolder, "*.dcm");
            watcher.Created += OnCreated;
            watcher.EnableRaisingEvents = true;

            // Keep the application running
            Console.WriteLine("Monitoring folder for DICOM files. Press Enter to exit.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void OnCreated(object sender, FileSystemEventArgs e)
    {
        try
        {
            // Verify the file exists before processing
            if (!File.Exists(e.FullPath))
            {
                Console.Error.WriteLine($"File not found: {e.FullPath}");
                return;
            }

            // Open the DICOM file as a stream
            using (Stream stream = File.OpenRead(e.FullPath))
            {
                // Load the DICOM image from the stream
                using (var dicomImage = new DicomImage(stream))
                {
                    // Process each page in the DICOM image
                    foreach (DicomPage dicomPage in dicomImage.DicomPages)
                    {
                        // Build the output PNG file path
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(e.Name)}.{dicomPage.Index}.png";
                        string outputPath = Path.Combine(outputFolder, outputFileName);

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        dicomPage.Save(outputPath, new PngOptions());
                    }
                }
            }

            Console.WriteLine($"Converted DICOM file '{e.Name}' to PNG images.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error processing file '{e.FullPath}': {ex.Message}");
        }
    }
}