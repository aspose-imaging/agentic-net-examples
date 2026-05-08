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
                    Console.Error.WriteLine("The loaded image is not an APNG.");
                    return;
                }

                // Iterate over each frame and save as JPEG
                for (int i = 0; i < apng.PageCount; i++)
                {
                    // Extract the frame as a RasterImage
                    using (RasterImage frame = (RasterImage)apng.Pages[i])
                    {
                        // Output file name with frame index
                        string outputPath = $"frame_{i}.jpg";

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                        // Save the frame as JPEG
                        var jpegOptions = new JpegOptions();
                        frame.Save(outputPath, jpegOptions);
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