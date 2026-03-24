using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"input.apng";
        string outputPath = @"output.apng";

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
            // Cast to ApngImage to access frame collection
            if (image is ApngImage apngImage)
            {
                // Iterate over each frame and apply a grayscale transformation
                for (int i = 0; i < apngImage.PageCount; i++)
                {
                    // Each page is a RasterImage; cast and manipulate
                    using (RasterImage frame = (RasterImage)apngImage.Pages[i])
                    {
                        frame.Grayscale();
                    }
                }

                // Save the modified APNG using default options
                apngImage.Save(outputPath, new ApngOptions());
            }
            else
            {
                Console.Error.WriteLine("The loaded image is not an APNG file.");
            }
        }
    }
}