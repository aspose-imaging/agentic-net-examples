using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input APNG file path
        string inputPath = @"C:\Images\animation.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Directory where extracted frames will be saved
        string outputDirectory = @"C:\Images\Frames";

        // Ensure the output directory exists (unconditional as per requirements)
        Directory.CreateDirectory(outputDirectory);

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access frames
            ApngImage apngImage = image as ApngImage;
            if (apngImage == null)
            {
                Console.Error.WriteLine("The provided file is not a valid APNG image.");
                return;
            }

            // Iterate through each frame (page) and save as a separate PNG file
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                // Retrieve the frame as a RasterImage
                using (RasterImage frame = (RasterImage)apngImage.Pages[i])
                {
                    // Build output file path for the current frame
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.png");

                    // Ensure the directory for the output file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the frame as PNG
                    frame.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}