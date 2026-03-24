using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input\\sample.wmf";
        string outputPath = "output\\sample_edited.wmf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Example editing operations:
            // Resize the image to new dimensions
            wmfImage.Resize(800, 600);

            // Rotate the image by 45 degrees around its center
            wmfImage.Rotate(45f);

            // Optionally change background color
            wmfImage.BackgroundColor = Color.White;

            // Save the modified WMF image
            wmfImage.Save(outputPath);
        }
    }
}