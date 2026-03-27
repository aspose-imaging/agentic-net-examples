using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output directories (relative paths)
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all files from the input directory
        string[] files = Directory.GetFiles(inputDirectory);
        foreach (string inputPath in files)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the file into a memory stream
            using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                memoryStream.Position = 0;

                // Load the image from the memory stream
                using (Image image = Image.Load(memoryStream))
                {
                    // Configure JPEG options with uniform quality
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 90 // Set desired quality (1-100)
                    };

                    // Determine output file path with .jpg extension
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory for this file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image as JPEG using the specified options
                    image.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}