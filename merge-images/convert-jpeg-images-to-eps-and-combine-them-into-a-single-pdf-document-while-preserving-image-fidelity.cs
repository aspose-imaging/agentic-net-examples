using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        var jpegFiles = new List<string>();
        jpegFiles.AddRange(Directory.GetFiles(inputDirectory, "*.jpg"));
        jpegFiles.AddRange(Directory.GetFiles(inputDirectory, "*.jpeg"));

        if (jpegFiles.Count == 0)
        {
            Console.WriteLine("No JPEG files found in the input directory.");
            return;
        }

        foreach (var jpegPath in jpegFiles)
        {
            if (!File.Exists(jpegPath))
            {
                Console.Error.WriteLine($"File not found: {jpegPath}");
                return;
            }

            string pdfPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(jpegPath) + ".pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            using (Image img = Image.Load(jpegPath))
            {
                img.Save(pdfPath, new PdfOptions());
            }

            Console.WriteLine($"Converted {jpegPath} to {pdfPath}");
        }

        Console.WriteLine("Conversion complete.");
    }
}