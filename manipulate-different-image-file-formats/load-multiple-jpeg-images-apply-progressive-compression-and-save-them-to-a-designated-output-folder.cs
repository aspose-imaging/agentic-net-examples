using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Get all JPEG files in the input folder
            string[] inputFiles = Directory.GetFiles(inputFolder, "*.jpg");

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding output path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + "_progressive.jpg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure JPEG options for progressive compression
                    JpegOptions saveOptions = new JpegOptions
                    {
                        CompressionType = JpegCompressionMode.Progressive,
                        Quality = 100 // optional: set desired quality (1‑100)
                    };

                    // Save the image with the specified options
                    image.Save(outputPath, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}