using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.jp2";
            string outputPath = @"C:\temp\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG2000 image using a 1 MB buffered stream
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream, 1024 * 1024))
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(bufferedStream))
            {
                // ----- Pixel processing can be performed here -----
                // Example: invert colors (placeholder - actual pixel manipulation code would go here)

                // Save as JPEG with 85% quality
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 85
                };
                jpeg2000Image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}