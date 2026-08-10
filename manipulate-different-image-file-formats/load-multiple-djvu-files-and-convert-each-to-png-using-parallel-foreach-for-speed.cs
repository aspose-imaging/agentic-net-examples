// HOW-TO: Convert Multiple DjVu Files to PNG in Parallel with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\InputDjvu";
        string outputFolder = @"C:\OutputPng";

        try
        {
            // Get all DjVu files in the input folder
            string[] inputFiles = Directory.GetFiles(inputFolder, "*.djvu");

            // Process each DjVu file in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the DjVu file stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Load the DjVu document
                    using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
                    {
                        // Iterate through each page and save as PNG
                        foreach (DjvuPage djvuPage in djvuImage.Pages)
                        {
                            // Build output file name: <originalname>_page<pageNumber>.png
                            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{djvuPage.PageNumber}.png";
                            string outputPath = Path.Combine(outputFolder, outputFileName);

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            djvuPage.Save(outputPath, new PngOptions());
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
 * 1. When you need to batch‑convert a large archive of DjVu documents into high‑quality PNG images for web publishing, this code speeds up the process by handling each file concurrently.
 * 2. When an application must extract every page of scanned DjVu manuals and save them as separate PNG files for inclusion in a searchable PDF workflow, the parallel loop reduces overall conversion time.
 * 3. When a server‑side service processes user‑uploaded DjVu files and must generate thumbnail PNG previews for each page without blocking other requests, this approach leverages multi‑core CPUs efficiently.
 * 4. When a digital library migrates legacy DjVu collections to a more widely supported PNG format and wants to automate the migration across thousands of files, the code provides a scalable solution.
 * 5. When a background job in a C# Windows service needs to convert DjVu pages to PNG for OCR preprocessing, using Parallel.ForEach ensures the job completes quickly while maintaining thread‑safe file handling.
 */
