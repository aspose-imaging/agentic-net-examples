using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.emf";
        string outputPath = @"C:\temp\output.emf";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare EMF save options (default settings)
                var saveOptions = new EmfOptions();

                // Open a file stream for efficient writing
                using (FileStream outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    // Save the image directly to the stream
                    image.Save(outStream, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application must copy or convert an EMF vector graphic from one location to another on a server while minimizing memory usage by streaming the output directly to a file.
 * 2. When a Windows service generates dynamic EMF reports and needs to write them to a network share in real time without loading the entire image into memory.
 * 3. When a batch processing tool handles thousands of EMF files and wants to save each processed image to disk efficiently using a FileStream to avoid performance bottlenecks.
 * 4. When an ASP.NET web API receives an EMF image upload, modifies it, and streams the result back to the client’s file system without creating temporary buffers.
 * 5. When a desktop application integrates with a legacy printing system that requires EMF files saved directly to a specific folder using stream‑based I/O for faster write operations.
 */