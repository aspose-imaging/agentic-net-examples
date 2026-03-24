using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Hardcoded output JPEG file
        string outputPath = @"C:\Images\Combined\combined.jpg";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load all input images
        Image[] images = new Image[inputPaths.Length];
        for (int i = 0; i < inputPaths.Length; i++)
        {
            images[i] = Image.Load(inputPaths[i]);
        }

        // Combine images into a multipage image
        using (Image combined = Image.Create(images))
        {
            // Save the combined image as a single JPEG file
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90 // Adjust quality as needed
            };
            combined.Save(outputPath, jpegOptions);
        }

        // Dispose loaded images (if not already disposed by Image.Create)
        foreach (var img in images)
        {
            img?.Dispose();
        }

        Console.WriteLine("Images combined successfully.");
    }
}