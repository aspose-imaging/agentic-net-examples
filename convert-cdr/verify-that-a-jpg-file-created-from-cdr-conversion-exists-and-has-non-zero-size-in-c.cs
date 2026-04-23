using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.cdr";
        string outputPath = @"C:\temp\output.jpg";

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

            // Load the CDR image from a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                var loadOptions = new LoadOptions(); // default load options
                using (CdrImage cdrImage = new CdrImage(stream, loadOptions))
                {
                    // Prepare JPEG save options (default quality)
                    var jpegOptions = new JpegOptions();

                    // Save the image as JPEG
                    cdrImage.Save(outputPath, jpegOptions);
                }
            }

            // Verify the JPEG file was created and has non‑zero size
            if (File.Exists(outputPath) && new FileInfo(outputPath).Length > 0)
            {
                Console.WriteLine("JPG file created successfully and is non‑zero size.");
            }
            else
            {
                Console.Error.WriteLine("Failed to create JPG or file is empty.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}