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
            // Hardcoded input and output directories
            string inputDir = "C:\\input\\";
            string outputDir = "C:\\output\\";

            // List of canvas image file names (for demonstration purposes)
            string[] inputFiles = new[] { "canvas1.png", "canvas2.png", "canvas3.png" };

            // Desired uniform JPEG quality (1-100)
            int jpegQuality = 85;

            foreach (var fileName in inputFiles)
            {
                // Build full input path
                string inputPath = Path.Combine(inputDir, fileName);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image into a memory stream
                using (MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(inputPath)))
                {
                    // Load Aspose.Imaging image from the stream
                    using (Image image = Image.Load(memoryStream))
                    {
                        // Configure JPEG save options with the uniform quality
                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Quality = jpegQuality
                        };

                        // Determine output file path (same name with .jpg extension)
                        string outputFileName = Path.ChangeExtension(fileName, ".jpg");
                        string outputPath = Path.Combine(outputDir, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the image as JPEG using the specified options
                        image.Save(outputPath, jpegOptions);
                    }
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
 * 1. When a web application needs to convert a batch of HTML5 Canvas screenshots stored in memory streams to JPEG files with a consistent compression quality for archival or reporting purposes.
 * 2. When an e‑learning platform generates PNG images from Canvas drawings on the client side and must batch‑process them on the server using C# and Aspose.Imaging to produce uniform‑quality JPEG thumbnails for faster loading.
 * 3. When a digital asset management system receives uploaded Canvas images as byte arrays and requires a reliable way to convert them to JPEG with a fixed quality setting before indexing them.
 * 4. When a marketing automation tool extracts Canvas graphics from email templates and needs to save them as JPEG files with the same quality level to ensure consistent visual appearance across campaigns.
 * 5. When a desktop utility written in .NET processes a list of Canvas‑generated PNG files from a temporary folder, loads them via memory streams, and saves them as JPEGs with a predefined quality to meet size‑restriction guidelines.
 */