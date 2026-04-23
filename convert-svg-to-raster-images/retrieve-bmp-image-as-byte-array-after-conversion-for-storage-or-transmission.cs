using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input path
        string inputPath = @"c:\temp\sample.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the BMP image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Define PNG save options (conversion from BMP to PNG)
            PngOptions pngOptions = new PngOptions();

            // Save the image to a memory stream to obtain a byte array
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, pngOptions);
                byte[] imageBytes = memoryStream.ToArray();

                // Output the size of the resulting byte array
                Console.WriteLine($"Converted image byte array length: {imageBytes.Length}");

                // Optional: write the byte array to a file for verification
                string outputPath = @"c:\temp\output.png";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                File.WriteAllBytes(outputPath, imageBytes);
            }
        }
    }
}