using System;
using System.IO;
using System.Threading;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomToPngService
{
    // Hardcoded input (watch) and output directories
    private const string WatchFolder = @"C:\DICOMInput";
    private const string OutputFolder = @"C:\PNGOutput";

    static void Main()
    {
        // Ensure the output directory exists
        Directory.CreateDirectory(OutputFolder);

        // Set up a watcher for new DICOM files (*.dcm)
        var watcher = new FileSystemWatcher(WatchFolder, "*.dcm");
        watcher.Created += OnCreated;
        watcher.EnableRaisingEvents = true;

        Console.WriteLine("Monitoring folder for new DICOM files. Press Enter to exit.");
        Console.ReadLine(); // Keep the application running
    }

    private static void OnCreated(object sender, FileSystemEventArgs e)
    {
        // Small delay to allow the file to be fully written
        Thread.Sleep(500);
        ProcessDicomFile(e.FullPath);
    }

    private static void ProcessDicomFile(string inputPath)
    {
        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Open the DICOM file as a stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load the DICOM image
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                // Iterate through each page in the DICOM image
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    // Build the output PNG file name: <originalName>.<pageIndex>.png
                    string baseName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputFileName = $"{baseName}.{dicomPage.Index}.png";
                    string outputPath = Path.Combine(OutputFolder, outputFileName);

                    // Ensure the output directory exists (unconditional per requirements)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    dicomPage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}