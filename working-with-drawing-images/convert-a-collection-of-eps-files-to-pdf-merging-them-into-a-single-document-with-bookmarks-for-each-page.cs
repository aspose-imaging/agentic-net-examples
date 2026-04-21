using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input EPS file paths
        string[] epsPaths = {
            "input1.eps",
            "input2.eps",
            "input3.eps"
        };

        // Hardcoded output PDF path
        string outputPath = "merged.pdf";

        // Validate each input file exists
        foreach (string path in epsPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists (guard against null)
        string outputDir = Path.GetDirectoryName(outputPath);
        if (string.IsNullOrWhiteSpace(outputDir))
        {
            outputDir = ".";
        }
        Directory.CreateDirectory(outputDir);

        // Load each EPS image into a list
        var images = new List<Aspose.Imaging.Image>();
        foreach (string path in epsPaths)
        {
            // Load EPS as generic Image (vector image handling is internal)
            Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(path);
            images.Add(img);
        }

        // Create a multipage image from the loaded EPS images
        using (Aspose.Imaging.Image result = Aspose.Imaging.Image.Create(images.ToArray(), true))
        {
            // Save the combined image as a PDF
            result.Save(outputPath, new PdfOptions());
        }

        // Dispose individual EPS images
        foreach (var img in images)
        {
            img.Dispose();
        }
    }
}