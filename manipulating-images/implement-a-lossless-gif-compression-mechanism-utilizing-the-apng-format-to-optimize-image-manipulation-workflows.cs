using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Image gifImage = Image.Load(inputPath))
        {
            // Configure APNG options (lossless by default)
            using (ApngOptions apngOptions = new ApngOptions())
            {
                // Save as APNG (PNG with animation support)
                gifImage.Save(outputPath, apngOptions);
            }
        }
    }
}