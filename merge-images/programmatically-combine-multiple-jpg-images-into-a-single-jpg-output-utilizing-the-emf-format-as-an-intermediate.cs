using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputFiles = new[]
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };

        // Verify each input file exists
        foreach (var inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Create a multipage image from the JPG files
        using (Image multiImage = Image.Create(inputFiles))
        {
            // Intermediate EMF file path
            string emfPath = @"C:\Images\combined.emf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(emfPath));

            // Save the multipage image as EMF (intermediate format)
            var emfOptions = new EmfOptions();
            multiImage.Save(emfPath, emfOptions);
        }

        // Load the intermediate EMF image
        string emfFilePath = @"C:\Images\combined.emf";
        if (!File.Exists(emfFilePath))
        {
            Console.Error.WriteLine($"File not found: {emfFilePath}");
            return;
        }

        using (Image emfImage = Image.Load(emfFilePath))
        {
            // Final JPEG output path
            string outputJpegPath = @"C:\Images\combined.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputJpegPath));

            // Save the EMF image as a single JPEG
            var jpegOptions = new JpegOptions
            {
                Quality = 90 // Adjust quality as needed
            };
            emfImage.Save(outputJpegPath, jpegOptions);
        }
    }
}