using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Hardcoded paths
    private const string InputFolder = @"C:\DicomInput";
    private const string OutputFolder = @"C:\PngOutput";

    static void Main()
    {
        try
        {
            // Ensure the output folder exists
            Directory.CreateDirectory(OutputFolder);

            // Set up a watcher for new DICOM files
            using (var watcher = new FileSystemWatcher(InputFolder, "*.dcm"))
            {
                watcher.Created += OnCreated;
                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Monitoring folder: " + InputFolder);
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine(); // Keep the application running
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void OnCreated(object sender, FileSystemEventArgs e)
    {
        // Give the file a moment to be fully written
        System.Threading.Thread.Sleep(500);
        ProcessDicomFile(e.FullPath, OutputFolder);
    }

    private static void ProcessDicomFile(string inputPath, string outputDir)
    {
        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (redundant but safe)
        Directory.CreateDirectory(outputDir);

        try
        {
            using (Stream stream = File.OpenRead(inputPath))
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                foreach (DicomPage page in dicomImage.DicomPages)
                {
                    string fileName = $"{Path.GetFileNameWithoutExtension(inputPath)}.{page.Index}.png";
                    string outputPath = Path.Combine(outputDir, fileName);

                    // Ensure the directory for this file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    page.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error processing '{inputPath}': {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a radiology department needs to automatically convert incoming DICOM scans to PNG for quick preview in web portals, this background service monitors the folder and performs the conversion.
 * 2. When a research lab wants to batch‑process newly saved DICOM files from imaging equipment into PNG thumbnails for inclusion in machine‑learning datasets, the code watches the directory and creates PNG images on the fly.
 * 3. When a hospital’s PACS integration requires real‑time generation of PNG snapshots for electronic health‑record (EHR) viewers, the FileSystemWatcher‑based service detects each new DICOM file and exports it as PNG.
 * 4. When a telemedicine platform must deliver patient imaging to mobile devices that only support PNG, the service continuously converts each incoming DICOM file to a PNG format compatible with the app.
 * 5. When a quality‑control workflow needs to archive visual representations of DICOM studies as PNG files for auditors, the background monitor automatically processes every newly added DICOM file and stores the PNG output.
 */