using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "c:\\temp\\input.dng";
            string outputPath = "c:\\temp\\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                DngImage dngImage = (DngImage)image;

                // Save as JPEG (Aspose.Imaging automatically converts to 8‑bit per channel)
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90 // optional quality setting
                };

                dngImage.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}