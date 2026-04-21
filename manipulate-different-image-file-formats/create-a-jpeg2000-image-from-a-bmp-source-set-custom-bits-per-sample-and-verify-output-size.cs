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
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.bmp";
        string outputPath = @"C:\Images\output.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image
        using (BmpImage bmpImage = new BmpImage(inputPath))
        {
            // Create JPEG2000 image from BMP raster with custom bits per pixel (e.g., 12)
            int customBitsPerPixel = 12;
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(bmpImage, customBitsPerPixel))
            {
                // Save JPEG2000 image with default options
                jpeg2000Image.Save(outputPath, new Jpeg2000Options());
            }
        }

        // Verify output file size
        if (File.Exists(outputPath))
        {
            long fileSize = new FileInfo(outputPath).Length;
            Console.WriteLine($"Output JPEG2000 file size: {fileSize} bytes");
        }
        else
        {
            Console.Error.WriteLine($"Failed to create output file: {outputPath}");
        }
    }
}