using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputDirectory = "output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (creates parent directories if needed)
        Directory.CreateDirectory(outputDirectory);

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access frames
            ApngImage apngImage = (ApngImage)image;

            // Iterate through each frame
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                // Get the frame as a RasterImage
                RasterImage frame = (RasterImage)apngImage.Pages[i];

                // Build output file path with frame index
                string outputPath = Path.Combine(outputDirectory, $"frame_{i}.jpg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the frame as JPEG
                frame.Save(outputPath, new JpegOptions());
            }
        }
    }
}