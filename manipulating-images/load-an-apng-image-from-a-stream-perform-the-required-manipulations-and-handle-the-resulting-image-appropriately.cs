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
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load APNG image from a file stream
        using (FileStream inputStream = File.OpenRead(inputPath))
        {
            Image image = Image.Load(inputStream);
            using (image)
            {
                // Cast to ApngImage to access APNG‑specific members (if needed)
                ApngImage apng = image as ApngImage;
                if (apng != null)
                {
                    // Example manipulation: set default frame time to 100 ms
                    apng.DefaultFrameTime = 100;
                }

                // Save the image as APNG using default options
                image.Save(outputPath, new ApngOptions());
            }
        }
    }
}