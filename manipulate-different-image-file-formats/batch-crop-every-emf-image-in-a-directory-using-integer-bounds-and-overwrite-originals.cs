// HOW-TO: Batch Crop Multiple EMF Files with Fixed Bounds in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";

            // Ensure the input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add EMF files and rerun.");
                return;
            }

            // Hardcoded crop bounds
            int cropX = 10;
            int cropY = 10;
            int cropWidth = 200;
            int cropHeight = 200;

            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf", SearchOption.TopDirectoryOnly);
            foreach (string inputPath in emfFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Ensure the directory for the output (same as input) exists
                Directory.CreateDirectory(Path.GetDirectoryName(inputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Perform cropping
                    Rectangle cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                    image.Crop(cropRect);

                    // Prepare EMF save options
                    EmfOptions exportOptions = new EmfOptions();
                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                    {
                        PageWidth = cropWidth,
                        PageHeight = cropHeight
                    };
                    exportOptions.VectorRasterizationOptions = vectorOptions;

                    // Overwrite the original file
                    image.Save(inputPath, exportOptions);
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
 * 1. When you need to remove unwanted margins from a set of EMF vector logos before publishing them.
 * 2. When an automated build process must standardize the size of EMF diagrams for a documentation pipeline.
 * 3. When a desktop application must quickly trim all EMF icons in a folder to a specific thumbnail dimension.
 * 4. When migrating legacy EMF assets and you want to overwrite the originals with a cropped version to save storage.
 * 5. When generating printable reports and you must ensure each EMF chart fits within a predefined page area.
 */
