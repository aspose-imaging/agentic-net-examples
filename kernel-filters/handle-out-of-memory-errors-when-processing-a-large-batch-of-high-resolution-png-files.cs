using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.CoreExceptions.ImageFormats;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\Input\highres1.png",
            @"C:\Images\Input\highres2.png",
            @"C:\Images\Input\highres3.png"
        };

        string[] outputPaths = new string[]
        {
            @"C:\Images\Output\highres1_processed.png",
            @"C:\Images\Output\highres2_processed.png",
            @"C:\Images\Output\highres3_processed.png"
        };

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

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
                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Example processing: convert to grayscale if it's a PNG
                    if (image is PngImage pngImage)
                    {
                        pngImage.Grayscale();
                    }

                    // Set memory limit for saving operation
                    PngOptions saveOptions = new PngOptions
                    {
                        BufferSizeHint = 200 // limit internal buffers to 200 MB
                    };

                    // Save the processed image
                    image.Save(outputPath, saveOptions);
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.Error.WriteLine($"Out of memory while processing {inputPath}: {ex.Message}");
                // Continue with next file
            }
            catch (ImageSaveException ex)
            {
                Console.Error.WriteLine($"Failed to save {outputPath}: {ex.Message}");
            }
            catch (PngImageException ex)
            {
                Console.Error.WriteLine($"PNG processing error for {inputPath}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error for {inputPath}: {ex.Message}");
            }
        }
    }
}