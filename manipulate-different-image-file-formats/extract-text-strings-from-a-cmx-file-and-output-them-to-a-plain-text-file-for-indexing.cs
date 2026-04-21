using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Cmx.ObjectModel;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.txt";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the CMX image
        using (CmxImage image = (CmxImage)Image.Load(inputPath))
        {
            // Access the CMX document
            CmxDocument document = image.Document;

            // Extract textual representation of the document
            string extractedText = document.ToString();

            // Write extracted text to the output file
            File.WriteAllText(outputPath, extractedText);
        }
    }
}