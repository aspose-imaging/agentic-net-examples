using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cdr";
        string outputPath = "result.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR file into a memory stream
        using (FileStream fileStream = File.OpenRead(inputPath))
        using (MemoryStream memoryStream = new MemoryStream())
        {
            fileStream.CopyTo(memoryStream);
            memoryStream.Position = 0; // Reset position for reading

            // Initialize load options (default)
            var loadOptions = new CdrLoadOptions();

            // Create CdrImage from the memory stream
            using (CdrImage cdrImage = new CdrImage(memoryStream, loadOptions))
            {
                // Optionally cache data to avoid further reads
                cdrImage.CacheData();

                // Set JPEG save options (default quality)
                var jpegOptions = new JpegOptions();

                // Save directly to JPG file
                cdrImage.Save(outputPath, jpegOptions);
            }
        }
    }
}