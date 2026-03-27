using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        // List of JPEG file names to process
        string[] files = new string[]
        {
            "photo1.jpg",
            "photo2.jpg",
            "photo3.jpg"
        };

        foreach (string fileName in files)
        {
            // Build full input and output paths
            string inputPath = Path.Combine(inputFolder, fileName);
            string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(fileName) + "_progressive.jpg");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options for progressive compression
                JpegOptions saveOptions = new JpegOptions
                {
                    CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                    Quality = 100 // optional: set desired quality (1-100)
                };

                // Save the image with the specified options
                image.Save(outputPath, saveOptions);
            }
        }
    }
}