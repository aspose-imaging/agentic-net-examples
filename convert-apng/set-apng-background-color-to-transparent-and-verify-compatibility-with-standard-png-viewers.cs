using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the APNG image
            using (ApngImage apngImage = (ApngImage)Image.Load(inputPath))
            {
                // Set background color to fully transparent
                apngImage.BackgroundColor = Aspose.Imaging.Color.Transparent;
                apngImage.HasBackgroundColor = true;

                // Save the modified APNG
                apngImage.Save(outputPath);
            }

            Console.WriteLine("APNG saved with transparent background.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}