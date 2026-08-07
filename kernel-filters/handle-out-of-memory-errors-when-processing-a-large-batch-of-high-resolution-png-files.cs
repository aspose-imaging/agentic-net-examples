using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output directories
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        try
        {
            // Get all PNG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.png");

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding output path
                string outputPath = Path.Combine(outputDir, Path.GetFileName(inputPath));

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                try
                {
                    // Load the PNG image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Set a memory limit for internal buffers to mitigate OOM
                        var saveOptions = new PngOptions
                        {
                            BufferSizeHint = 200 // limit to 200 MB
                        };

                        // Save the image using the specified options
                        image.Save(outputPath, saveOptions);
                    }
                }
                catch (OutOfMemoryException oome)
                {
                    // Handle out‑of‑memory situations gracefully
                    Console.Error.WriteLine($"Out of memory processing {inputPath}: {oome.Message}");
                }
                catch (PngImageException pngEx)
                {
                    // Handle PNG‑specific errors
                    Console.Error.WriteLine($"PNG error processing {inputPath}: {pngEx.Message}");
                }
                catch (Exception ex)
                {
                    // Handle any other errors for this file
                    Console.Error.WriteLine($"Error processing {inputPath}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            // Global error handling
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application must convert or re‑save a large batch of high‑resolution PNG files without crashing due to out‑of‑memory errors, this Aspose.Imaging code can be used to limit internal buffer size and handle OOM exceptions.
 * 2. When processing thousands of 8K PNG images for a digital asset management system, developers can use this pattern to ensure each file is loaded, saved, and any memory‑limit issues are logged instead of terminating the whole job.
 * 3. When building an automated image pipeline that reads PNG files from a network share and writes them to a different folder, the code helps gracefully skip files that exceed available RAM by catching OutOfMemoryException.
 * 4. When integrating Aspose.Imaging into a C# console tool that resaves PNGs with specific options (e.g., BufferSizeHint) to reduce memory pressure on low‑end servers, this example shows the required try‑catch structure.
 * 5. When a developer needs to validate the existence of input PNGs, create missing output directories, and protect the batch process from memory spikes while using Aspose.Imaging’s PngOptions, this snippet provides a ready‑to‑use solution.
 */