using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Validate input directory
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPG files, then rerun.");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Define paths for JPG images (all JPG files in the input folder)
        string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg");
        string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");
        var imageFiles = new System.Collections.Generic.List<string>();
        imageFiles.AddRange(jpgFiles);
        imageFiles.AddRange(jpegFiles);

        // Validate that there is at least one image
        if (imageFiles.Count == 0)
        {
            Console.WriteLine("No JPG images found in the input directory.");
            return;
        }

        // Validate each image file exists
        foreach (string imgPath in imageFiles)
        {
            if (!File.Exists(imgPath))
            {
                Console.Error.WriteLine($"File not found: {imgPath}");
                return;
            }
        }

        // Create PDF options
        PdfOptions pdfOptions = new PdfOptions();
        pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();

        // Load the first image and save as PDF
        string firstImagePath = imageFiles[0];
        using (Image image = Image.Load(firstImagePath))
        {
            string outputPath = Path.Combine(outputDirectory, "Combined.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            image.Save(outputPath, pdfOptions);
        }

        Console.WriteLine("PDF document created successfully.");
    }
}