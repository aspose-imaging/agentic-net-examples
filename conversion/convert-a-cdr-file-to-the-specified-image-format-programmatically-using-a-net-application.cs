using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.cdr";
        string outputPath = "sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
        Directory.CreateDirectory(outputDir);

        // Load the CDR image using Aspose.Imaging
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath, new CdrLoadOptions()))
        {
            // Define PNG save options (default options are sufficient for basic conversion)
            PngOptions pngOptions = new PngOptions();

            // Save the image to the desired format
            cdrImage.Save(outputPath, pngOptions);
        }
    }
}