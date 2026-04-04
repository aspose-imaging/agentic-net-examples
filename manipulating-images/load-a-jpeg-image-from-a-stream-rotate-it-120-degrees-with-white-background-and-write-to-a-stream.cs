using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image from a file stream
        using (FileStream inputStream = File.OpenRead(inputPath))
        using (JpegImage jpegImage = new JpegImage(inputStream))
        {
            // Rotate 120 degrees clockwise, resize proportionally, fill empty area with white
            jpegImage.Rotate(120f, true, Aspose.Imaging.Color.White);

            // Save the rotated image to the output file stream using default JPEG options
            using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
            {
                var saveOptions = new JpegOptions(); // default options
                jpegImage.Save(outputStream, saveOptions);
            }
        }
    }
}