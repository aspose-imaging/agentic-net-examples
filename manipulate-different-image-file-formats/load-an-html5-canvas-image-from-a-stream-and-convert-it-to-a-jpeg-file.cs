using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\canvas.html";
            string outputPath = @"C:\Temp\Result\canvas.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image from a file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                using (Image image = Image.Load(inputStream))
                {
                    // Set JPEG save options (default settings)
                    JpegOptions jpegOptions = new JpegOptions();

                    // Save the image as JPEG
                    image.Save(outputPath, jpegOptions);
                }
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
 * 1. When a web application generates charts on an HTML5 Canvas and needs to archive them as JPEG files on the server using C# and Aspose.Imaging.
 * 2. When a desktop utility processes user‑uploaded canvas.html files and converts them to JPEG thumbnails for preview in a file manager.
 * 3. When an automated reporting tool reads HTML5 Canvas images from a network share via a stream and saves them as JPEGs for inclusion in PDF reports.
 * 4. When a migration script converts legacy HTML5 Canvas assets stored in a database BLOB into JPEG files for a content management system.
 * 5. When a background service validates the existence of a canvas.html file, loads it from a stream, and stores a compressed JPEG version to reduce storage costs.
 */