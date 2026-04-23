using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputCdrFiles";
            string outputDirectory = @"C:\OutputJpgFiles";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all CDR files in the input directory
            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Cache all pages to avoid repeated loading
                    cdrImage.CacheData();
                    foreach (CdrImagePage page in cdrImage.Pages)
                    {
                        page.CacheData();

                        // Prepare output file name with timestamp
                        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        string baseName = Path.GetFileNameWithoutExtension(inputPath);
                        string outputFileName = $"{baseName}_{timestamp}.jpg";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Set JPEG save options
                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Quality = 90
                        };

                        // Save the page as JPEG
                        page.Save(outputPath, jpegOptions);
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