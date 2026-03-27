using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EMF image from a memory stream
        byte[] emfData = File.ReadAllBytes(inputPath);
        using (MemoryStream ms = new MemoryStream(emfData))
        using (Image emfImage = Image.Load(ms))
        {
            // Save the image as PDF
            emfImage.Save(outputPath, new PdfOptions());
        }
    }
}