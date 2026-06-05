using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cdr";
        string outputPath = "output.png";

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

            // Load CDR file into a byte array
            byte[] cdrBytes = File.ReadAllBytes(inputPath);

            // Create a memory stream from the byte array
            using (MemoryStream inputStream = new MemoryStream(cdrBytes))
            {
                // Initialize load options for CDR format
                CdrLoadOptions loadOptions = new CdrLoadOptions();

                // Load the CDR image from the stream
                using (CdrImage cdrImage = new CdrImage(inputStream, loadOptions))
                {
                    // Optional: cache data to avoid lazy loading
                    cdrImage.CacheData();

                    // Prepare a memory stream for the PNG output
                    using (MemoryStream pngStream = new MemoryStream())
                    {
                        // Set PNG save options (default settings)
                        PngOptions pngOptions = new PngOptions();

                        // Save the CDR image as PNG into the memory stream
                        cdrImage.Save(pngStream, pngOptions);

                        // Reset stream position for further reading or copying
                        pngStream.Position = 0;

                        // Optionally write the PNG data to a file
                        using (FileStream fileOut = File.Open(outputPath, FileMode.Create, FileAccess.Write))
                        {
                            pngStream.CopyTo(fileOut);
                        }

                        // At this point, pngStream contains the PNG data in memory
                        // It can be used further as needed
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