using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.bmp";
        string outputPath = "Output\\sample.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When a web application allows users to upload BMP images and must convert them to PNG for browser compatibility while catching unsupported format errors.
 * 2. When a desktop utility processes scanned BMP files and needs to save them as PNG without crashing if the BMP version is not supported.
 * 3. When an automated batch job reads BMP files from a folder, converts them to PNG, and logs a friendly error message if Aspose.Imaging cannot load the image.
 * 4. When a cloud service receives BMP uploads via an API, validates the file existence, creates the output directory, and gracefully handles exceptions during image conversion.
 * 5. When a mobile backend service transforms user‑submitted BMP pictures to PNG thumbnails and must inform the user when the BMP format is unsupported.
 */