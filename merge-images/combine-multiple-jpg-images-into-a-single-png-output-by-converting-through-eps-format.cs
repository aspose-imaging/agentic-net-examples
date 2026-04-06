using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new[]
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Hardcoded temporary EPS file and final PNG output
        string epsPath = @"C:\Images\combined.eps";
        string outputPath = @"C:\Images\combined.png";

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(epsPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPG files
        // Using the rule: Image.Create(string[] files)
        using (Image multipageImage = Image.Create(inputPaths))
        {
            // Save the multipage image as EPS (intermediate format)
            // The Save method will infer EPS format from the file extension
            multipageImage.Save(epsPath);
        }

        // Load the EPS image
        using (Image epsImage = Image.Load(epsPath))
        {
            // Prepare PNG save options (optional, can use defaults)
            PngOptions pngOptions = new PngOptions();

            // Save the EPS image as a single PNG file
            epsImage.Save(outputPath, pngOptions);
        }

        Console.WriteLine("Combined image saved to: " + outputPath);
    }
}