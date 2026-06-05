using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\readonly_output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Open a read‑only file stream (simulating a read‑only destination)
                using (FileStream roStream = new FileStream(outputPath, FileMode.Create, FileAccess.Read, FileShare.None))
                {
                    try
                    {
                        // Attempt to save the image to the read‑only stream
                        BmpOptions saveOptions = new BmpOptions();
                        image.Save(roStream, saveOptions);
                    }
                    catch (BmpImageException ex)
                    {
                        // Handle BMP‑specific errors
                        Console.Error.WriteLine($"BmpImageException: {ex.Message}");
                    }
                    catch (ImageSaveException ex)
                    {
                        // Handle generic image‑saving errors
                        Console.Error.WriteLine($"ImageSaveException: {ex.Message}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application needs to generate a BMP thumbnail and write it to a network share that is configured as read‑only, the code catches the ImageSaveException to prevent the program from crashing.
 * 2. When an automated image‑processing service runs on a server with restricted file‑system permissions, this pattern ensures that attempts to save BMP files to a read‑only stream are logged instead of causing unhandled exceptions.
 * 3. When a desktop utility converts user‑uploaded images to BMP format but the destination folder is set to read‑only for security compliance, the error handling informs the user why the save operation failed.
 * 4. When a batch job processes large numbers of BMP files and some output paths are inadvertently marked as read‑only, the BmpImageException catch block isolates format‑specific issues from generic I/O errors.
 * 5. When integrating Aspose.Imaging into a CI/CD pipeline that writes BMP artifacts to a read‑only artifact repository, the try‑catch structure provides clear diagnostics for permission‑related save failures.
 */