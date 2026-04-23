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
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // Retrieve all DNG files from the input directory
            string[] dngFiles = Directory.GetFiles(inputDir, "*.dng");

            foreach (string inputPath in dngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Construct the output JPEG file path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DNG image and save it as JPEG with quality 85
                using (Image image = Image.Load(inputPath))
                {
                    DngImage dngImage = (DngImage)image;
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 85
                    };
                    dngImage.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}