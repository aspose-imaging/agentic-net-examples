using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.html";
        string outputPath = "output.jpg";

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

            // Load the HTML5 Canvas image from a file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                // Optional: verify that the stream can be loaded as an image
                if (!Image.CanLoad(inputStream))
                {
                    Console.Error.WriteLine($"Cannot load image from: {inputPath}");
                    return;
                }

                // Reset stream position after CanLoad check
                inputStream.Position = 0;

                // Load the image
                using (Image image = Image.Load(inputStream))
                {
                    // Prepare JPEG save options (default settings)
                    var jpegOptions = new JpegOptions();

                    // Save the image as JPEG to the specified output path
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
 * 1. When a web application generates dynamic graphics on an HTML5 Canvas and needs to store them as JPEG files on the server using C# and Aspose.Imaging.
 * 2. When a desktop utility processes uploaded HTML5 Canvas files from a file stream and converts them to JPEG for archival or printing purposes.
 * 3. When an automated batch job scans a folder of .html canvas exports, validates each file, and saves them as JPEG images with default compression settings via Aspose.Imaging in .NET.
 * 4. When a content management system receives canvas snapshots from browsers, loads them from a stream, and creates JPEG thumbnails for fast preview in a gallery.
 * 5. When a developer wants to ensure the output directory exists, verify the input HTML5 Canvas can be loaded, and then convert the canvas to a JPEG using Image.Load and JpegOptions in a try‑catch block.
 */