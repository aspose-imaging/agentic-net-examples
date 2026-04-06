using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string baseDir = @"C:\temp\";

        string[] inputPaths = new string[]
        {
            Path.Combine(baseDir, "image1.jpg"),
            Path.Combine(baseDir, "image2.jpg"),
            Path.Combine(baseDir, "image3.jpg")
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

        // Path for the intermediate multi‑page TIFF
        string tiffPath = Path.Combine(baseDir, "combined.tif");
        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(tiffPath));

        // Create a multipage image (TIFF) from the JPG files
        using (Image multiPageImage = Image.Create(inputPaths))
        {
            // Save as TIFF with default options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            multiPageImage.Save(tiffPath, tiffOptions);
        }

        // Verify the intermediate TIFF was created
        if (!File.Exists(tiffPath))
        {
            Console.Error.WriteLine($"Failed to create intermediate TIFF: {tiffPath}");
            return;
        }

        // Path for the final PDF output
        string pdfPath = Path.Combine(baseDir, "combined.pdf");
        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

        // Load the intermediate TIFF and save it as PDF
        using (Image tiffImage = Image.Load(tiffPath))
        {
            // Saving with a .pdf extension lets Aspose infer PDF format
            tiffImage.Save(pdfPath);
        }
    }
}