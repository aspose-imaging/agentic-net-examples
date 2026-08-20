// HOW-TO: Retry Loading Image on Transient I/O Errors in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Imaging;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Retry mechanism for transient I/O errors during image loading
            Image image = null;
            const int maxRetries = 3;
            int attempt = 0;
            while (attempt < maxRetries)
            {
                try
                {
                    image = Image.Load(inputPath);
                    break; // Loaded successfully
                }
                catch (ImageLoadException ex) // Transient load error
                {
                    attempt++;
                    if (attempt >= maxRetries)
                    {
                        Console.Error.WriteLine($"Failed to load image after {maxRetries} attempts: {ex.Message}");
                        return;
                    }
                    Thread.Sleep(500); // Wait before retrying
                }
                catch (IOException ex) // Other I/O errors
                {
                    attempt++;
                    if (attempt >= maxRetries)
                    {
                        Console.Error.WriteLine($"IO error loading image after {maxRetries} attempts: {ex.Message}");
                        return;
                    }
                    Thread.Sleep(500);
                }
            }

            if (image == null)
            {
                Console.Error.WriteLine("Image could not be loaded.");
                return;
            }

            using (image)
            {
                // Example filter: convert to grayscale (placeholder for actual processing)
                // image.ConvertToGrayscale(); // Uncomment if method is available

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When a web service intermittently fails to read a JPEG file from disk, you can use this retry logic to ensure the image loads before applying filters.
 * 2. When processing a batch of high‑resolution PNGs on a shared network drive, the code helps recover from temporary I/O timeouts by retrying the load operation.
 * 3. When integrating Aspose.Imaging into an automated photo‑editing pipeline, the retry mechanism prevents the entire workflow from stopping due to occasional file‑access glitches.
 * 4. When deploying a Windows service that monitors a folder for new TIFF images, the sample shows how to handle transient read errors before performing image transformations.
 * 5. When building a desktop C# application that applies filters to user‑selected images, this pattern safeguards against occasional disk‑read failures caused by antivirus scans or network latency.
 */
