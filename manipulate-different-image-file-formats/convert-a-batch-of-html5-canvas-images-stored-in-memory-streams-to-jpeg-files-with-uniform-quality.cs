using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = "C:\\input\\";
        string outputDir = "C:\\output\\";
        // Ensure the output base directory exists
        Directory.CreateDirectory(outputDir);

        // List of input file names (HTML5 Canvas images stored as files)
        string[] inputFiles = new string[]
        {
            "canvas1.png",
            "canvas2.png",
            "canvas3.png"
        };

        // Uniform JPEG quality for all output images
        int jpegQuality = 80;

        for (int i = 0; i < inputFiles.Length; i++)
        {
            string inputPath = Path.Combine(inputDir, inputFiles[i]);

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
                memoryStream.Position = 0; // Reset position for reading

                // Load image from the memory stream
                using (Image image = Image.Load(memoryStream))
                {
                    // Configure JPEG save options with the desired quality
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = jpegQuality
                    };

                    // Define output file path
                    string outputFileName = $"canvas{i + 1}.jpg";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Ensure the output directory exists (unconditional as required)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image as JPEG using the specified options
                    image.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}