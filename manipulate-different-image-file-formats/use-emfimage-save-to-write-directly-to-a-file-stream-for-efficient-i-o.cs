using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.emf";
            string outputPath = @"C:\temp\output.emf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image (unified loader works for EMF)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access EMF‑specific members
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not an EMF image.");
                    return;
                }

                // Open a file stream for efficient writing
                using (FileStream outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    // Save directly to the stream using EMF options
                    EmfOptions options = new EmfOptions();
                    emfImage.Save(outStream, options);
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
 * 1. When a C# application must copy or convert an existing EMF file to a new location on a server while minimizing memory usage by streaming the output directly to a FileStream.
 * 2. When generating reports that embed vector graphics and need to save the EMF content to a network share in real time without loading the entire image into memory.
 * 3. When processing large batches of EMF files in a background service and want to write each processed image efficiently to disk using Aspose.Imaging’s EmfOptions.
 * 4. When integrating a .NET web API that receives EMF data, modifies it, and streams the result back to the client as a downloadable file.
 * 5. When implementing a low‑latency document conversion pipeline that reads an EMF source, applies transformations, and writes the result to a temporary file stream for further processing.
 */