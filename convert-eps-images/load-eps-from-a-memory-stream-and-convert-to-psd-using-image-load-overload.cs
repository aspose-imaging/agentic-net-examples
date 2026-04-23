using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.psd";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load EPS image from a memory stream
        using (MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(inputPath)))
        using (Image image = Image.Load(memoryStream))
        {
            // Prepare PSD save options
            PsdOptions psdOptions = new PsdOptions();

            // Save the image as PSD
            image.Save(outputPath, psdOptions);
        }
    }
}