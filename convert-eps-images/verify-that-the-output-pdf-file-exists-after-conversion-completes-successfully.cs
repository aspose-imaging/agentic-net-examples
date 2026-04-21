using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main()
    {
        string inputPath = "Input/sample.jpg";
        string outputPath = "Output/sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        using (PdfOptions pdfOptions = new PdfOptions())
        {
            image.Save(outputPath, pdfOptions);
        }

        if (File.Exists(outputPath))
        {
            Console.WriteLine($"PDF file successfully created: {outputPath}");
        }
        else
        {
            Console.Error.WriteLine($"Failed to create PDF file: {outputPath}");
        }
    }
}