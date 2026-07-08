using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string watchFolder = @"C:\DICOM\Watch";
            string outputFolder = @"C:\DICOM\Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Set up a watcher for new DICOM files
            using (var watcher = new FileSystemWatcher(watchFolder, "*.dcm"))
            {
                watcher.Created += (sender, e) =>
                {
                    // Give the file some time to be fully written
                    System.Threading.Thread.Sleep(500);

                    string inputPath = e.FullPath;
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Build output file name (same base name with .png)
                    string baseName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, $"{baseName}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    try
                    {
                        // Load DICOM image from file stream
                        using (Stream stream = File.OpenRead(inputPath))
                        using (DicomImage dicomImage = new DicomImage(stream))
                        {
                            // If the DICOM has multiple pages, save each page separately
                            int pageIndex = 0;
                            foreach (var dicomPage in dicomImage.DicomPages)
                            {
                                string pageOutputPath = Path.Combine(
                                    outputFolder,
                                    $"{baseName}_page{pageIndex}.png");

                                Directory.CreateDirectory(Path.GetDirectoryName(pageOutputPath));

                                dicomPage.Save(pageOutputPath, new PngOptions());
                                pageIndex++;
                            }

                            // If there is only one page, also save the generic outputPath
                            if (pageIndex == 1)
                            {
                                dicomImage.DicomPages[0].Save(outputPath, new PngOptions());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Error processing file '{inputPath}': {ex.Message}");
                    }
                };

                watcher.EnableRaisingEvents = true;

                Console.WriteLine($"Monitoring folder: {watchFolder}");
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine(); // Keep the application running
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a radiology department needs an automated background service that watches a network folder for incoming DICOM (.dcm) scans and instantly converts each file to a PNG for quick preview in web portals.
 * 2. When a research lab wants to monitor a data acquisition folder and transform multi‑page DICOM images into separate PNG pages for downstream image analysis pipelines using C# and Aspose.Imaging.
 * 3. When a hospital IT team must ensure that every new DICOM study saved to a PACS export directory is automatically saved as PNG thumbnails for integration with electronic health record (EHR) systems.
 * 4. When a telemedicine application requires a real‑time file watcher that detects newly uploaded DICOM files and generates PNG assets for mobile device display without manual intervention.
 * 5. When a quality‑control workflow needs to continuously convert incoming DICOM files to lossless PNGs so that non‑medical staff can review and annotate images using standard image viewers.
 */