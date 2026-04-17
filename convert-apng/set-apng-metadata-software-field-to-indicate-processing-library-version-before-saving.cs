using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.apng";
        string outputPath = @"C:\temp\output.apng";

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
            // Cast to ApngImage to access APNG-specific members
            ApngImage apngImage = image as ApngImage;
            if (apngImage == null)
            {
                Console.Error.WriteLine("The loaded file is not a valid APNG image.");
                return;
            }

            // Create PNG metadata and set the Software field
            PngMetadata pngMetadata = new PngMetadata
            {
                Software = "Aspose.Imaging v2.0"
            };

            // Apply the metadata to the APNG image
            apngImage.TrySetMetadata(pngMetadata);

            // Save the modified APNG image
            apngImage.Save(outputPath);
        }
    }
}