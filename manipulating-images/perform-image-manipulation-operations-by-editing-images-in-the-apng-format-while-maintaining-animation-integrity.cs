using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Check that the loaded image is an APNG
            if (image is ApngImage apngImage)
            {
                // Iterate over each frame and adjust its gamma
                for (int i = 0; i < apngImage.PageCount; i++)
                {
                    ApngFrame frame = (ApngFrame)apngImage.Pages[i];
                    // Example gamma adjustment: increase gamma progressively per frame
                    float gamma = 1.0f + i * 0.1f;
                    frame.AdjustGamma(gamma);
                }

                // Save the modified APNG using default ApngOptions
                apngImage.Save(outputPath, new ApngOptions());
            }
            else
            {
                Console.Error.WriteLine("The loaded image is not an APNG.");
            }
        }
    }
}