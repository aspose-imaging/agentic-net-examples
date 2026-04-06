using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputJpgPaths = new[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Hardcoded output PDF file
        string outputPdfPath = @"C:\Images\Combined.pdf";

        // Temporary folder for intermediate DNG files
        string tempFolder = @"C:\Images\TempDng";

        // Ensure the temporary folder exists
        Directory.CreateDirectory(tempFolder);

        // Verify each input file exists
        foreach (string jpgPath in inputJpgPaths)
        {
            if (!File.Exists(jpgPath))
            {
                Console.Error.WriteLine($"File not found: {jpgPath}");
                return;
            }
        }

        // List to hold paths of generated DNG files
        List<string> dngPaths = new List<string>();

        // Convert each JPG to DNG
        foreach (string jpgPath in inputJpgPaths)
        {
            // Load JPG image
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Determine DNG file path
                string dngFileName = Path.GetFileNameWithoutExtension(jpgPath) + ".dng";
                string dngPath = Path.Combine(tempFolder, dngFileName);

                // Save as DNG (format inferred from extension)
                jpgImage.Save(dngPath);
                dngPaths.Add(dngPath);
            }
        }

        // Load each DNG image into memory
        List<Image> dngImages = new List<Image>();
        foreach (string dngPath in dngPaths)
        {
            if (!File.Exists(dngPath))
            {
                Console.Error.WriteLine($"File not found: {dngPath}");
                return;
            }

            Image dngImage = Image.Load(dngPath);
            dngImages.Add(dngImage);
        }

        // Create a multipage image from the DNG images
        Image[] dngImageArray = dngImages.ToArray();
        using (Image multipageImage = Image.Create(dngImageArray))
        {
            // Prepare PDF options
            PdfOptions pdfOptions = new PdfOptions();

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Save the multipage image as a PDF document
            multipageImage.Save(outputPdfPath, pdfOptions);
        }

        // Dispose loaded DNG images (if not already disposed by multipageImage)
        foreach (var img in dngImages)
        {
            img.Dispose();
        }

        // Optionally clean up temporary DNG files
        // foreach (var dngPath in dngPaths) { File.Delete(dngPath); }
    }
}