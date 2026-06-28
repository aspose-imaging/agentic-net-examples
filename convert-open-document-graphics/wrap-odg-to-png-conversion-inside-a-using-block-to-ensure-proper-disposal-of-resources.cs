using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load ODG image and save as PNG inside a using block for proper disposal
            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application needs to display OpenDocument graphics (ODG) in a Windows Forms picture box that only supports PNG, a developer can use this code to convert the ODG file to PNG while ensuring resources are released with a using block.
 * 2. When an automated batch‑processing service must generate web‑ready thumbnails from a collection of ODG diagrams, the snippet provides a reliable way to load each ODG, save it as PNG, and automatically dispose of the Image object.
 * 3. When integrating Aspose.Imaging into a C# microservice that receives ODG uploads and returns PNG responses, the code demonstrates how to perform the conversion safely by wrapping Image.Load in a using statement.
 * 4. When a build pipeline includes a step to convert design assets stored as ODG into PNG for inclusion in documentation, this example shows the proper file‑existence checks and resource cleanup needed in .NET.
 * 5. When a developer is writing a plugin for a content‑management system that must transform user‑provided ODG files into PNG for preview thumbnails, the sample illustrates the essential C# operations and disposal pattern.
 */