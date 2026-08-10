// HOW-TO: Automatically Convert New DICOM Files to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Hardcoded folders to watch and to place PNG files.
    private const string InputFolder = @"C:\InputDicom";
    private const string OutputFolder = @"C:\OutputPng";

    static void Main()
    {
        try
        {
            // Ensure the output directory exists.
            Directory.CreateDirectory(OutputFolder);

            // Set up a watcher for new DICOM files.
            using (var watcher = new FileSystemWatcher(InputFolder, "*.dcm"))
            {
                watcher.Created += OnCreated;
                watcher.EnableRaisingEvents = true;

                Console.WriteLine($"Monitoring folder: {InputFolder}");
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine(); // Keep the application running.
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Event handler triggered when a new file appears.
    private static void OnCreated(object sender, FileSystemEventArgs e)
    {
        // Small delay to ensure the file is fully written.
        System.Threading.Thread.Sleep(500);
        ProcessDicomFile(e.FullPath);
    }

    // Converts each page of the DICOM file to a separate PNG image.
    private static void ProcessDicomFile(string inputPath)
    {
        // Verify the input file exists.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Open the DICOM file as a stream.
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DICOM image.
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through all pages.
                    foreach (var dicomPage in dicomImage.DicomPages)
                    {
                        // Build the output PNG file name.
                        string fileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_{dicomPage.Index}.png";
                        string outputPath = Path.Combine(OutputFolder, fileName);

                        // Ensure the directory for the output file exists.
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG.
                        dicomPage.Save(outputPath, new PngOptions());
                    }
                }
            }

            Console.WriteLine($"Converted: {inputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error processing {inputPath}: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a radiology department needs to automatically generate PNG previews of incoming DICOM scans for quick viewing in web portals.
 * 2. When a medical research lab wants to build a pipeline that watches a folder for new DICOM images and saves each slice as PNG for downstream analysis.
 * 3. When a hospital’s PACS system must export DICOM studies to PNG files for integration with electronic health record (EHR) viewers.
 * 4. When a telemedicine application requires real‑time conversion of uploaded DICOM files to PNG so clinicians can view images on any device without DICOM support.
 * 5. When a machine‑learning team needs to continuously create PNG training data from DICOM files as they are received in a shared directory.
 */
