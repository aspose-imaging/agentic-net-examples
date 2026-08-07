using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Process only vector images
                if (image is VectorImage vectorImage)
                {
                    // Attempt to remove background; handle case where no vector shapes are present
                    try
                    {
                        vectorImage.RemoveBackground();
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"RemoveBackground failed: {ex.Message}");
                        // Continue without background removal
                    }

                    // Save the (possibly modified) vector image
                    vectorImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a vector image.");
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
 * 1. When an e‑commerce platform receives vendor‑uploaded SVG product images and must attempt to strip the background but continue without failure if the SVG contains no vector shapes.
 * 2. When a desktop publishing tool runs a nightly script to clean up SVG icons for a mobile app and needs to catch the “no shapes” exception so the script can still save the original file.
 * 3. When an automated CI/CD pipeline validates UI assets and uses Aspose.Imaging to remove backgrounds, it must handle cases where a designer’s placeholder SVG has only metadata, ensuring the build does not stop.
 * 4. When a cloud‑based image‑optimization service processes mixed SVG and PDF inputs and must detect and log files that lack vector paths while still delivering the unmodified output to the client.
 * 5. When a Windows service monitors a folder for new vector graphics and applies background removal, it needs robust error handling to skip files that are empty or contain only raster images without interrupting the monitoring loop.
 */