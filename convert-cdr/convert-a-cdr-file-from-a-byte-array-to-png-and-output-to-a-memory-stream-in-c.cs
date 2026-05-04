using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output\\output.png";

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

            // Load the CDR file into a byte array
            byte[] cdrData = File.ReadAllBytes(inputPath);

            // Create a memory stream from the byte array
            using (var inputStream = new MemoryStream(cdrData))
            {
                // Initialize load options (default)
                var loadOptions = new CdrLoadOptions();

                // Load CDR image from the stream
                using (var cdrImage = new CdrImage(inputStream, loadOptions))
                {
                    // Optional: cache all data to avoid lazy loading
                    cdrImage.CacheData();

                    // Prepare a memory stream for the PNG output
                    using (var outputStream = new MemoryStream())
                    {
                        // Set PNG save options (default)
                        var pngOptions = new PngOptions();

                        // Save the image as PNG into the memory stream
                        cdrImage.Save(outputStream, pngOptions);

                        // Example usage: display the size of the generated PNG data
                        Console.WriteLine($"PNG data size: {outputStream.Length} bytes");
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