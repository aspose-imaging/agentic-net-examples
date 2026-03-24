using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample_copy.emf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image into memory
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access EMF-specific members
            EmfImage emfImage = image as EmfImage;
            if (emfImage == null)
            {
                Console.Error.WriteLine("The loaded file is not an EMF image.");
                return;
            }

            // Optionally cache data to force loading of all records
            emfImage.CacheData();

            // Example: display basic image information
            Console.WriteLine($"Width: {emfImage.Width}, Height: {emfImage.Height}");
            Console.WriteLine($"Number of records: {emfImage.Records.Count}");

            // Save a copy of the image (demonstrates safe save handling)
            emfImage.Save(outputPath);
        }
    }
}