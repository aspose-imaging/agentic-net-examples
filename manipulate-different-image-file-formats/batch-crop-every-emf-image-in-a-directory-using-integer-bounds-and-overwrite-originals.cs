using System;
using System.IO;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input directory containing EMF files
        string inputDirectory = "InputEmf";

        // Ensure the input directory exists; create if missing and exit
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add EMF files and rerun.");
            return;
        }

        // Get all EMF files in the directory
        string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

        foreach (string inputPath in emfFiles)
        {
            // Verify the file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Load the EMF image
            using (Aspose.Imaging.FileFormats.Emf.EmfImage emfImage = (Aspose.Imaging.FileFormats.Emf.EmfImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Crop 10 pixels from each side (left, top, right, bottom)
                emfImage.Crop(10, 10, 10, 10);

                // Ensure the output directory exists before saving
                Directory.CreateDirectory(Path.GetDirectoryName(inputPath));

                // Overwrite the original file with the cropped image
                emfImage.Save(inputPath);
            }
        }
    }
}