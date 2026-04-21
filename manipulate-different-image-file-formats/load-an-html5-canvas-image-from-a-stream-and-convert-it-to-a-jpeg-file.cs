using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.html";
        string outputPath = @"C:\Temp\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the HTML5 Canvas image from a file stream
        using (FileStream inputStream = File.OpenRead(inputPath))
        using (Image image = Image.Load(inputStream))
        {
            // Prepare JPEG save options (default settings)
            JpegOptions jpegOptions = new JpegOptions();

            // Save the image as JPEG to a file stream
            using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
            {
                image.Save(outputStream, jpegOptions);
            }
        }
    }
}