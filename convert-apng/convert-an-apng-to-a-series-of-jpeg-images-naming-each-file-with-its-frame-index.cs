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
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputDir = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the APNG image
            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                // JPEG save options
                JpegOptions jpegOptions = new JpegOptions();

                // Export each frame as a separate JPEG file
                for (int i = 0; i < apng.PageCount; i++)
                {
                    string outPath = Path.Combine(outputDir, $"frame_{i}.jpg");
                    // Ensure directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                    // Save the current frame
                    apng.Pages[i].Save(outPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}