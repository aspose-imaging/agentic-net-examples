using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input image path
        string inputPath = @"C:\Images\input.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory
        string outputDir = @"C:\Images\Output";

        // Ensure the output directory exists (unconditional per rule)
        Directory.CreateDirectory(outputDir);

        // Desired dimensions for resizing
        int newWidth = 800;
        int newHeight = 600;

        // Resize types to evaluate
        ResizeType[] resizeTypes = new ResizeType[]
        {
            ResizeType.NearestNeighbourResample,
            ResizeType.BilinearResample,
            ResizeType.LanczosResample,
            ResizeType.HighQualityResample,
            ResizeType.CatmullRom,
            ResizeType.Mitchell
        };

        foreach (ResizeType resizeType in resizeTypes)
        {
            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Perform resizing with the specific ResizeType
                image.Resize(newWidth, newHeight, resizeType);

                // Construct output file path
                string outputPath = Path.Combine(outputDir, $"resized_{resizeType}.jpg");

                // Ensure the directory for the output file exists (unconditional per rule)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the resized image as JPEG
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);

                // Retrieve and display the file size
                long fileSize = new FileInfo(outputPath).Length;
                Console.WriteLine($"{resizeType}: {fileSize} bytes");
            }
        }
    }
}