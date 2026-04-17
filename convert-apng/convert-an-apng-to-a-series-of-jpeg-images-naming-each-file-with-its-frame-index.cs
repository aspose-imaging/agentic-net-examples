using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
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
            ApngImage apngImage = image as ApngImage;
            if (apngImage == null)
            {
                Console.Error.WriteLine("The loaded file is not an APNG image.");
                return;
            }

            // Iterate through each frame
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                // Extract the frame as a RasterImage
                using (RasterImage frame = (RasterImage)apngImage.Pages[i])
                {
                    // Build output file name with frame index
                    string outputPath = $"frame_{i}.jpg";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                    // Save the frame as JPEG
                    JpegOptions jpegOptions = new JpegOptions();
                    frame.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}