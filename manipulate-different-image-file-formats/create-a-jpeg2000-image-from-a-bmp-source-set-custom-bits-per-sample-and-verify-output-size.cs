using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\sample_output.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (BmpImage bmpImage = (BmpImage)Image.Load(inputPath))
            {
                // Create JPEG2000 image from BMP with custom bits per pixel (e.g., 12)
                int customBitsPerPixel = 12;
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(bmpImage, customBitsPerPixel))
                {
                    // Save JPEG2000 image
                    jpeg2000Image.Save(outputPath);
                }
            }

            // Verify output file size
            FileInfo info = new FileInfo(outputPath);
            Console.WriteLine($"Output file size: {info.Length} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}