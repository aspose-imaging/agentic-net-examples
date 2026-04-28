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
                // Cast to ApngImage to access APNG‑specific properties
                ApngImage apngImage = image as ApngImage;
                if (apngImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not an APNG.");
                    return;
                }

                // Set background color to fully transparent
                apngImage.BackgroundColor = Aspose.Imaging.Color.Transparent;
                apngImage.HasBackgroundColor = true;

                // Save the modified APNG using default APNG options
                ApngOptions saveOptions = new ApngOptions();
                apngImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}