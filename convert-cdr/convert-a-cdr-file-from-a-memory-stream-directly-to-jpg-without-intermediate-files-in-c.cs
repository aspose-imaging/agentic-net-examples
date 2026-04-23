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
        string inputPath = @"C:\Temp\sample.cdr";
        string outputPath = @"C:\Temp\output.jpg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CDR file into a memory stream
            using (MemoryStream inputStream = new MemoryStream(File.ReadAllBytes(inputPath)))
            {
                // Initialize load options for CDR
                CdrLoadOptions loadOptions = new CdrLoadOptions();

                // Create CdrImage from the memory stream
                using (CdrImage cdrImage = new CdrImage(inputStream, loadOptions))
                {
                    // Prepare JPEG save options (default settings)
                    JpegOptions jpegOptions = new JpegOptions();

                    // Save directly to the output JPG file
                    cdrImage.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}