using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.emf";
        string outputPath = @"C:\temp\output.emf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage for EMF-specific operations
            EmfImage emfImage = image as EmfImage;
            if (emfImage == null)
            {
                Console.Error.WriteLine("The loaded file is not a valid EMF image.");
                return;
            }

            // Prepare EMF save options (default options are sufficient for this example)
            EmfOptions saveOptions = new EmfOptions();

            // Open a file stream for the output file
            using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                // Save the EMF image directly to the stream
                emfImage.Save(outputStream, saveOptions);
            }
        }
    }
}