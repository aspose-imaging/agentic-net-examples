using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Hardcoded paths
    private const string WatchFolder = @"C:\DICOM\Incoming";
    private const string OutputFolder = @"C:\DICOM\Converted";

    static void Main()
    {
        try
        {
            // Ensure the output base directory exists
            Directory.CreateDirectory(OutputFolder);

            // Set up a watcher for new files in the watch folder
            var watcher = new FileSystemWatcher(WatchFolder)
            {
                Filter = "*.*",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime,
                EnableRaisingEvents = true
            };

            watcher.Created += OnCreated;

            // Keep the application running
            Console.WriteLine("Monitoring folder for new DICOM files. Press Enter to exit.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void OnCreated(object sender, FileSystemEventArgs e)
    {
        // Process only DICOM files (common extensions)
        string extension = Path.GetExtension(e.FullPath).ToLowerInvariant();
        if (extension != ".dcm" && extension != ".dicom")
        {
            return;
        }

        // Ensure the file exists before processing
        if (!File.Exists(e.FullPath))
        {
            Console.Error.WriteLine($"File not found: {e.FullPath}");
            return;
        }

        // Wait briefly to allow the file to be fully written
        for (int i = 0; i < 5; i++)
        {
            try
            {
                using (FileStream testStream = File.Open(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    break; // File is ready
                }
            }
            catch
            {
                System.Threading.Thread.Sleep(500);
            }
        }

        try
        {
            // Open the DICOM file as a stream
            using (Stream stream = File.OpenRead(e.FullPath))
            {
                // Load the DICOM image
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page and save as PNG
                    foreach (var dicomPage in dicomImage.DicomPages)
                    {
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(e.Name)}_page{dicomPage.Index}.png";
                        string outputPath = Path.Combine(OutputFolder, outputFileName);

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        dicomPage.Save(outputPath, new PngOptions());
                    }
                }
            }

            Console.WriteLine($"Converted DICOM file: {e.Name}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error processing file '{e.FullPath}': {ex.Message}");
        }
    }
}