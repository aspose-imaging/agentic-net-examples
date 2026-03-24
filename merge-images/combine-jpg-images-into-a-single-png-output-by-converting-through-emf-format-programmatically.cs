using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputJpgPaths = new[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Verify each input file exists
        foreach (var path in inputJpgPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Temporary folder for intermediate EMF files
        string tempEmfFolder = @"C:\Temp\EmfTmp";
        Directory.CreateDirectory(Path.GetDirectoryName(tempEmfFolder)); // ensure parent exists
        Directory.CreateDirectory(tempEmfFolder);

        var emfPaths = new List<string>();

        // Convert each JPG to EMF
        foreach (var jpgPath in inputJpgPaths)
        {
            string emfPath = Path.Combine(tempEmfFolder,
                Path.GetFileNameWithoutExtension(jpgPath) + ".emf");

            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Prepare EMF rasterization options matching the source size
                var emfRasterOptions = new EmfRasterizationOptions
                {
                    PageSize = jpgImage.Size
                };

                var emfSaveOptions = new EmfOptions
                {
                    VectorRasterizationOptions = emfRasterOptions
                };

                jpgImage.Save(emfPath, emfSaveOptions);
            }

            emfPaths.Add(emfPath);
        }

        // Create a multipage image from the generated EMF files
        using (Image multipageEmf = Image.Create(emfPaths.ToArray()))
        {
            // Output PNG path
            string outputPngPath = @"C:\Output\combined.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));

            // PNG save options (vector rasterization will be applied automatically)
            var pngOptions = new PngOptions();

            // Save the combined image as a single PNG
            multipageEmf.Save(outputPngPath, pngOptions);
        }

        // Cleanup temporary EMF files (optional)
        foreach (var emfFile in emfPaths)
        {
            try { File.Delete(emfFile); } catch { /* ignore cleanup errors */ }
        }
    }
}