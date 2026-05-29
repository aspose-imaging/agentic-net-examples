using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = "input.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.Error.WriteLine("The loaded file is not an APNG image.");
                    return;
                }

                int frameCount = apng.PageCount;

                // Iterate through each frame and save as a separate PNG file
                for (int i = 0; i < frameCount; i++)
                {
                    // Retrieve the frame as a RasterImage
                    using (RasterImage frame = (RasterImage)apng.Pages[i])
                    {
                        // Hardcoded output path for each frame
                        string outputPath = $"frame_{i:D4}.png";

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                        // Save the frame as PNG
                        frame.Save(outputPath, new PngOptions());
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