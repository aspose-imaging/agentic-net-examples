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
        try
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

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.Error.WriteLine("The loaded image is not an APNG.");
                    return;
                }

                int frameCount = apng.PageCount;

                // Iterate through each frame and save as BMP
                for (int i = 0; i < frameCount; i++)
                {
                    // Retrieve the frame as a RasterImage
                    using (RasterImage frame = (RasterImage)apng.Pages[i])
                    {
                        // Build output file path
                        string outputPath = Path.Combine(outputDirectory, $"frame_{i:D4}.bmp");

                        // Ensure the directory for this output path exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the frame as BMP using default options
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