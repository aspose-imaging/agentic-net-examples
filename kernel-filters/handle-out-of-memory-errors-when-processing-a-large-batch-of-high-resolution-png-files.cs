using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            // Validate output directory
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_processed.png");

                // Set PNG options with a memory limit to mitigate out‑of‑memory issues
                PngOptions options = new PngOptions
                {
                    BufferSizeHint = 100 // limit internal buffers to 100 MB
                };

                try
                {
                    // Load the image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Ensure the output directory for this file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the image with the specified options
                        image.Save(outputPath, options);
                    }
                }
                catch (OutOfMemoryException oomEx)
                {
                    Console.Error.WriteLine($"Out of memory while processing {inputPath}: {oomEx.Message}");
                    // Continue with next file
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error processing {inputPath}: {ex.Message}");
                    // Continue with next file
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
 * 1. When a web service must convert thousands of high‑resolution PNG assets to a standardized format without crashing due to memory limits, this code can batch‑process them safely.
 * 2. When an automated build pipeline generates large PNG screenshots from UI tests and needs to resize or apply filters while preventing out‑of‑memory exceptions, the sample provides a reliable approach.
 * 3. When a desktop application imports a folder of 4K PNG images for archival and must ensure each file is loaded, processed, and saved without exhausting the .NET heap, the code demonstrates proper memory‑bounded handling.
 * 4. When a cloud‑based image‑processing microservice receives a bulk upload of high‑detail PNG files and must write processed copies to a separate directory while respecting a 100 MB buffer limit, this pattern is applicable.
 * 5. When a data‑migration script moves legacy PNG graphics to a new storage location and applies PNGOptions to limit internal buffers, it helps avoid out‑of‑memory errors during large‑scale batch operations.
 */