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
            string inputDir = @"C:\temp\input";
            string outputDir = @"C:\temp\output";

            // Process each file found in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDir))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding output JPEG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".jpg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image from the input file stream
                using (FileStream inputStream = File.OpenRead(inputPath))
                using (Image image = Image.Load(inputStream))
                {
                    // Set JPEG save options with uniform quality
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 80 // desired uniform quality (1-100)
                    };

                    // Save the image as JPEG to the output path
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
 * 1. When a web application needs to export a batch of HTML5 Canvas drawings saved as temporary files into compressed JPEGs with a consistent quality setting for faster download.
 * 2. When an e‑learning platform must generate thumbnail previews from user‑uploaded canvas images and store them as uniform‑quality JPEG files on the server.
 * 3. When a digital asset management system requires automated conversion of stored canvas snapshots into JPEG format to ensure compatibility with legacy image viewers.
 * 4. When a reporting tool has to batch‑process canvas‑based charts saved in memory streams and produce JPEG images with a fixed 80 % quality for inclusion in PDF reports.
 * 5. When a mobile backend service needs to normalize the size and compression of canvas‑generated screenshots by converting them to JPEG files with a standard quality level before archiving.
 */