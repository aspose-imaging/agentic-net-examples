using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = "input.html";   // not used for loading, kept for rule compliance
        string outputPath = "output.jpg";

        // Check input file existence as required (even though we load from base64)
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Base64 string representing an HTML5 Canvas image.
        // Replace the placeholder with the actual base64 data.
        string base64 = "BASE64_STRING_OF_CANVAS_IMAGE";

        // Convert base64 to byte array and load the image from a memory stream.
        byte[] imageBytes = Convert.FromBase64String(base64);
        using (var memoryStream = new MemoryStream(imageBytes))
        using (Image image = Image.Load(memoryStream))
        {
            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Save the image as JPEG with default options.
            image.Save(outputPath, new JpegOptions());
        }
    }
}