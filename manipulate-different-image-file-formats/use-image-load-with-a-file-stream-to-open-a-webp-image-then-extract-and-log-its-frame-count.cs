using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.webp";
            string outputPath = "C:\\temp\\framecount.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open a file stream for the WebP image
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load the image from the stream
                using (Image image = Image.Load(stream))
                {
                    // Cast to WebPImage to access PageCount (frame count)
                    WebPImage webPImage = image as WebPImage;
                    int frameCount = webPImage != null ? webPImage.PageCount : 0;

                    // Log the frame count to console
                    Console.WriteLine($"Frame count: {frameCount}");

                    // Write the frame count to the output file
                    File.WriteAllText(outputPath, $"Frame count: {frameCount}");
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
 * 1. When a developer wants to verify the number of animation frames in a WebP image before processing it for a web carousel, they can use Image.Load with a FileStream to read the file and log the frame count.
 * 2. When building a server‑side image‑validation service that rejects multi‑frame WebP files exceeding a certain limit, the code can load the image from a stream and extract the PageCount for comparison.
 * 3. When generating a report of assets in a digital‑asset‑management system, a developer can read each WebP file via a stream, obtain its frame count, and write the result to a log file for inventory purposes.
 * 4. When creating a batch‑processing tool that converts animated WebP files to GIFs only if they contain more than one frame, the code demonstrates how to load the image, read the frame count, and decide the next step.
 * 5. When troubleshooting rendering issues in a C# application that displays WebP animations, a developer can use this snippet to load the image from a stream, output the frame count to the console, and confirm the source file’s structure.
 */