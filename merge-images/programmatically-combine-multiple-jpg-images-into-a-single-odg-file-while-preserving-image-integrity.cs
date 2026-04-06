using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hard‑coded output ODG file
        string outputPath = @"C:\Images\combined.odg";

        // Verify each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load each JPG image
        Image[] loadedImages = new Image[inputPaths.Length];
        for (int i = 0; i < inputPaths.Length; i++)
        {
            loadedImages[i] = Image.Load(inputPaths[i]);
        }

        // Create a multipage image (ODG) from the loaded JPGs.
        // The overload with 'disposeImages' set to true will dispose the source images automatically.
        using (Image odgImage = Image.Create(loadedImages, true))
        {
            // Save the combined image as ODG
            odgImage.Save(outputPath);
        }
    }
}