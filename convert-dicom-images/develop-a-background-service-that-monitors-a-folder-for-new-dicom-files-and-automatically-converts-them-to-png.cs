using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Hardcoded folders to watch and to store PNG files
    private const string InputFolder = @"C:\DicomInput";
    private const string OutputFolder = @"C:\PngOutput";

    static void Main()
    {
        try
        {
            // Ensure the output base folder exists
            Directory.CreateDirectory(OutputFolder);

            // Set up a watcher for new files in the input folder
            var watcher = new FileSystemWatcher(InputFolder)
            {
                Filter = "*.*",               // watch all files
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime,
                EnableRaisingEvents = true
            };

            // Subscribe to the Created event
            watcher.Created += OnNewFileDetected;

            // Keep the application running
            Console.WriteLine("Monitoring folder for DICOM files. Press Enter to exit.");
            Console.ReadLine();

            // Clean up
            watcher.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Event handler called when a new file appears in the input folder
    private static void OnNewFileDetected(object sender, FileSystemEventArgs e)
    {
        // Process only DICOM files (common extensions)
        string extension = Path.GetExtension(e.FullPath).ToLowerInvariant();
        if (extension != ".dcm" && extension != ".dicom")
        {
            return;
        }

        // Verify the file actually exists
        if (!File.Exists(e.FullPath))
        {
            Console.Error.WriteLine($"File not found: {e.FullPath}");
            return;
        }

        // Build the base output path (same file name without extension)
        string baseFileName = Path.GetFileNameWithoutExtension(e.FullPath);
        string fileOutputFolder = Path.Combine(OutputFolder, baseFileName);

        // Ensure the folder for this file's PNGs exists
        Directory.CreateDirectory(fileOutputFolder);

        try
        {
            // Open the DICOM file as a stream
            using (Stream stream = File.OpenRead(e.FullPath))
            {
                // Load the DICOM image from the stream
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate over each page and save as PNG
                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        string pngPath = Path.Combine(fileOutputFolder, $"{baseFileName}_{page.Index}.png");

                        // Ensure the directory for the PNG exists (already created above)
                        Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

                        // Save the page as PNG using Aspose.Imaging's PngOptions
                        page.Save(pngPath, new PngOptions());
                    }
                }
            }

            Console.WriteLine($"Converted DICOM '{e.Name}' to PNG(s) in '{fileOutputFolder}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error processing file '{e.FullPath}': {ex.Message}");
        }
    }
}