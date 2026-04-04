using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input/input.png";
        string outputPath = "output/output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image, resize, and save as JPEG with quality setting
        using (Image image = Image.Load(inputPath))
        {
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            image.Resize(newWidth, newHeight);

            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 80 // Desired JPEG quality (1-100)
            };

            image.Save(outputPath, jpegOptions);
        }
    }
}