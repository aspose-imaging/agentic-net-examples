using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cdr";
        string outputPath = "sample.jpg";

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

            // Load the CDR file into a memory stream
            byte[] cdrBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream inputStream = new MemoryStream(cdrBytes))
            {
                // Initialize load options (default)
                var loadOptions = new CdrLoadOptions();

                // Create CdrImage from the memory stream
                using (CdrImage cdrImage = new CdrImage(inputStream, loadOptions))
                {
                    // Optional: cache all data to avoid further stream reads
                    cdrImage.CacheData();

                    // Prepare output file stream
                    using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        // Set JPEG save options (default quality)
                        var jpegOptions = new JpegOptions();

                        // Save directly to the output stream in JPEG format
                        cdrImage.Save(outputStream, jpegOptions);
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