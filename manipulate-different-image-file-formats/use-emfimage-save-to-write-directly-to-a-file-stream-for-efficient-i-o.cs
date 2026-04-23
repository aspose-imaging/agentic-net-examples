using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected exceptions
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.emf";
            string outputPath = @"C:\temp\output.emf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if missing)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (EMF or any supported format)
            using (Image image = Image.Load(inputPath))
            {
                // Prepare EMF save options (default settings)
                EmfOptions emfOptions = new EmfOptions();

                // Open a file stream for the output file
                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                {
                    // Save the image directly to the stream using EMF options
                    image.Save(outStream, emfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}