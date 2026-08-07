using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "readonly_output.bmp";

        // Global exception handling
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare BMP save options (default)
                BmpOptions saveOptions = new BmpOptions();

                // Open the output file as a read‑only stream
                using (FileStream readOnlyStream = new FileStream(
                    outputPath,
                    FileMode.OpenOrCreate,
                    FileAccess.Read,
                    FileShare.Read))
                {
                    try
                    {
                        // Attempt to save the image to the read‑only stream
                        image.Save(readOnlyStream, saveOptions);
                        Console.WriteLine("Image saved successfully (unexpected).");
                    }
                    catch (BmpImageException bmpEx)
                    {
                        Console.Error.WriteLine($"BMP image error: {bmpEx.Message}");
                    }
                    catch (ImageSaveException saveEx)
                    {
                        Console.Error.WriteLine($"Image save error: {saveEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"General error while saving: {ex.Message}");
                    }
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
 * 1. When an application generates BMP thumbnails and attempts to write them to a network share that is configured as read‑only, the code can catch the save exception and log a meaningful error.
 * 2. When a Windows service processes scanned documents and tries to overwrite a protected BMP file, the error handling prevents the service from crashing and allows fallback to an alternate folder.
 * 3. When a desktop utility updates image metadata but the target BMP file is opened by another program in read‑only mode, the try‑catch block reports the ImageSaveException to the user.
 * 4. When a batch conversion tool runs on a server with limited write permissions and encounters a read‑only stream for BMP output, the code captures BmpImageException to inform administrators.
 * 5. When a cloud‑based image processing pipeline stores BMP results in a read‑only blob storage container, the exception handling ensures graceful degradation and retries with a writable stream.
 */