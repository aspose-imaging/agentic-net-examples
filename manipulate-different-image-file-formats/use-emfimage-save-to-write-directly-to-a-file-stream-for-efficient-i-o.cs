// HOW-TO: Save EMF Image Directly to File Stream in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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

            // Load the image (unified loader works for all formats, including EMF)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access EMF‑specific functionality
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not an EMF image.");
                    return;
                }

                // Prepare EMF save options (default options are sufficient for a direct copy)
                EmfOptions saveOptions = new EmfOptions();

                // Open a file stream for the output file and save directly to it
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
 * 1. When you need to copy or modify an EMF file without loading the entire image into memory, you can stream it directly to disk using Aspose.Imaging in C#.
 * 2. When building a server‑side service that receives EMF graphics and must store them efficiently, writing the image to a FileStream avoids extra buffering.
 * 3. When processing large batches of EMF drawings in a background job, streaming each save operation reduces memory pressure and speeds up I/O.
 * 4. When integrating with legacy Windows applications that generate EMF files and require the files to be saved to a specific folder, the code lets you write them directly from C#.
 * 5. When you want to preserve the original EMF metadata while re‑saving the file after applying Aspose.Imaging transformations, using EmfImage.Save with a stream ensures a lossless copy.
 */
