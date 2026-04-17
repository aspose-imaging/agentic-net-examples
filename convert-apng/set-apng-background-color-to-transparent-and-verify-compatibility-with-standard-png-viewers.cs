using System;
using System.IO;
using Aspose.Imaging;
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

        // Ensure output directory exists (unconditional call)
        string outDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outDir ?? ".");

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            ApngImage apng = image as ApngImage;
            if (apng == null)
            {
                Console.Error.WriteLine("Loaded image is not an APNG.");
                return;
            }

            // Set background color to fully transparent
            apng.BackgroundColor = Aspose.Imaging.Color.Transparent;
            apng.HasBackgroundColor = true;

            // Save the modified APNG
            apng.Save(outputPath);
        }
    }
}