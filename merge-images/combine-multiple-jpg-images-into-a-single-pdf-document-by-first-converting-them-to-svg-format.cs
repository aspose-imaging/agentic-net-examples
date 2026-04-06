using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Set up input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPG files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all JPG files in the input directory
        string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg");
        if (jpgFiles.Length == 0)
        {
            Console.WriteLine("No JPG files found in the input directory.");
            return;
        }

        // Convert each JPG to SVG
        foreach (string jpgPath in jpgFiles)
        {
            if (!File.Exists(jpgPath))
            {
                Console.Error.WriteLine($"File not found: {jpgPath}");
                return;
            }

            string svgPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(jpgPath) + ".svg");
            Directory.CreateDirectory(Path.GetDirectoryName(svgPath));

            using (Image image = Image.Load(jpgPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                image.Save(svgPath, svgOptions);
            }
        }

        // Collect all generated SVG files
        string[] svgFiles = Directory.GetFiles(outputDirectory, "*.svg");
        if (svgFiles.Length == 0)
        {
            Console.WriteLine("No SVG files were created.");
            return;
        }

        // Load SVG images into a list
        List<Image> svgImages = new List<Image>();
        foreach (string svgPath in svgFiles)
        {
            if (!File.Exists(svgPath))
            {
                Console.Error.WriteLine($"File not found: {svgPath}");
                return;
            }
            svgImages.Add(Image.Load(svgPath));
        }

        // Create a multipage image from SVGs and save as PDF
        string pdfPath = Path.Combine(outputDirectory, "Combined.pdf");
        Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

        using (Image pdfImage = Image.Create(svgImages.ToArray(), true))
        {
            var pdfOptions = new PdfOptions();
            pdfImage.Save(pdfPath, pdfOptions);
        }
    }
}