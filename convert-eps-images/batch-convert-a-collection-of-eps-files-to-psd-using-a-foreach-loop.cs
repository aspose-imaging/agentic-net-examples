// HOW-TO: Batch Convert Multiple EPS Files to PSD Using C# Loop (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Define input and output directories relative to the current directory
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            // Ensure the input directory exists; if not, create it and exit
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all EPS files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.eps");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PSD file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".psd");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EPS image and cast to EpsImage
                using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
                {
                    // Create PSD save options
                    var psdOptions = new PsdOptions();

                    // Save the image as PSD
                    epsImage.Save(outputPath, psdOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically transform a folder of vector EPS artwork into editable Photoshop PSD layers for a design pipeline.
 * 2. When a print‑to‑digital workflow requires converting client‑supplied EPS logos to PSD files before further editing in Adobe Photoshop.
 * 3. When you want to script a bulk image migration from legacy EPS assets to PSD format in a C# application without manual intervention.
 * 4. When integrating Aspose.Imaging into a server‑side service that processes incoming EPS files and stores them as PSDs for downstream processing.
 * 5. When preparing a batch of EPS illustrations for a web‑based preview system that only supports PSD thumbnails generated via C#.
 */
