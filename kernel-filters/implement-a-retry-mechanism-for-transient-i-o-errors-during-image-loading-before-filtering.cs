using System;
using System.IO;
using System.Threading;
using Aspose.Imaging;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Retry policy for transient I/O errors while loading the image
            const int maxRetries = 3;
            const int delayMs = 500;
            Image image = null;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    // Load the image using Aspose.Imaging
                    image = Image.Load(inputPath);
                    break; // Success – exit retry loop
                }
                catch (ImageLoadException ex)
                {
                    // Transient load failure – retry unless this was the last attempt
                    if (attempt == maxRetries)
                        throw; // Re‑throw to be caught by outer catch

                    Thread.Sleep(delayMs);
                }
                catch (IOException ex)
                {
                    // Transient I/O failure – retry unless this was the last attempt
                    if (attempt == maxRetries)
                        throw;

                    Thread.Sleep(delayMs);
                }
            }

            // At this point 'image' is guaranteed to be non‑null
            using (image)
            {
                // Example filter: convert to grayscale (simple pixel manipulation)
                // Note: Aspose.Imaging provides built‑in filters; here we use a basic approach.
                // For brevity, we just save the original image.
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}