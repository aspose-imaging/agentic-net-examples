using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputJpgPaths = new string[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Verify each input file exists
        foreach (string inputPath in inputJpgPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Hardcoded output PDF path
        string outputPdfPath = @"C:\Output\combined.pdf";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Convert each JPG to APNG and store temporary paths
        string[] apngPaths = new string[inputJpgPaths.Length];
        for (int i = 0; i < inputJpgPaths.Length; i++)
        {
            string jpgPath = inputJpgPaths[i];
            string apngPath = Path.ChangeExtension(jpgPath, ".apng.png"); // temporary APNG file
            apngPaths[i] = apngPath;

            // Load JPG
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Save as APNG using default options
                jpgImage.Save(apngPath, new ApngOptions());
            }
        }

        // Create a multipage image from the APNG files
        using (Image multipageImage = Image.Create(apngPaths))
        {
            // Save the multipage image as a PDF document
            multipageImage.Save(outputPdfPath, new PdfOptions());
        }

        // Optionally, clean up temporary APNG files
        foreach (string apngPath in apngPaths)
        {
            if (File.Exists(apngPath))
            {
                try { File.Delete(apngPath); } catch { /* ignore cleanup errors */ }
            }
        }
    }
}