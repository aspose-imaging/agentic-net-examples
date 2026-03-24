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
        string[] inputPaths = new[]
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };

        // Hardcoded output PNG file
        string outputPath = @"C:\Images\combined_output.png";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Load all JPG images into a list
        List<Image> loadedImages = new List<Image>();
        foreach (string inputPath in inputPaths)
        {
            // Load image using Aspose.Imaging.Image.Load
            Image img = Image.Load(inputPath);
            loadedImages.Add(img);
        }

        // Create a multipage image (PSD) from the loaded images
        // Using the Create(Image[]) overload
        Image[] imagesArray = loadedImages.ToArray();
        Image psdImage = Image.Create(imagesArray);

        // Save the intermediate PSD file
        string tempPsdPath = @"C:\Images\temp_combined.psd";
        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(tempPsdPath));
        var psdOptions = new PsdOptions();
        psdImage.Save(tempPsdPath, psdOptions);

        // Dispose the temporary PSD image (the source images are still needed for final step)
        psdImage.Dispose();

        // Load the saved PSD and export it to PNG
        using (Image psdLoaded = Image.Load(tempPsdPath))
        {
            // Ensure the final output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            // Save as PNG using default PngOptions
            psdLoaded.Save(outputPath, new PngOptions());
        }

        // Dispose all loaded JPG images
        foreach (var img in loadedImages)
        {
            img.Dispose();
        }
    }
}