using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates if missing)
            Directory.CreateDirectory(outputDirectory);

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames
                ApngImage apngImage = (ApngImage)image;
                int frameCount = apngImage.PageCount;

                // Iterate over each frame and save as BMP
                for (int i = 0; i < frameCount; i++)
                {
                    // Build output file path for the current frame
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i:D4}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Extract the frame as a RasterImage
                    using (RasterImage frame = (RasterImage)apngImage.Pages[i])
                    {
                        // Save the frame as BMP using default BmpOptions
                        BmpOptions bmpOptions = new BmpOptions();
                        frame.Save(outputPath, bmpOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}