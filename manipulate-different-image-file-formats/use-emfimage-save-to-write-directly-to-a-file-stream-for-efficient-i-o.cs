using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.emf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image (unified load works for EMF)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access EMF‑specific members
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not an EMF image.");
                    return;
                }

                // Create default EMF save options (can be customized if needed)
                EmfOptions saveOptions = new EmfOptions();

                // Save directly to a file stream for efficient I/O
                using (FileStream outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    emfImage.Save(outStream, saveOptions);
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

/*
 * Real-World Use Cases:
 * 1. When a C# application must copy or convert an EMF vector graphic on a server while keeping memory usage low, it can load the EMF with Aspose.Imaging and save it directly to a FileStream.
 * 2. When generating printable reports that embed EMF logos and the output needs to be written to a network share without loading the entire image into memory, developers can use EmfImage.Save with a FileStream.
 * 3. When building a batch‑processing tool that reads EMF files from a folder, applies optional transformations, and writes the results to another location with high I/O performance, the direct‑stream save method is ideal.
 * 4. When integrating EMF image export into a web API that streams the file to the client on the fly, using EmfImage.Save to a response stream avoids temporary files and reduces latency.
 * 5. When implementing a background service that archives incoming EMF drawings to a compressed archive and needs to write each image directly to a stream for efficient disk I/O, this code pattern is appropriate.
 */