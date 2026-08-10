// HOW-TO: Remove Background From CDR File When Objects Match Original Background In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr; // Namespace for CDR support (if needed)
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_no_background.cdr";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Cast to VectorImage (CDR files are vector images)
                if (image is VectorImage vectorImage)
                {
                    // Remove the background using default settings
                    vectorImage.RemoveBackground();

                    // Save the result
                    vectorImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("The loaded file is not a vector image.");
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
 * 1. When you need to automatically delete a solid background from a CorelDRAW (CDR) illustration that has foreground shapes the same color as the original canvas.
 * 2. When preparing CDR artwork for web publishing and you must ensure the background is transparent without manually editing each object.
 * 3. When batch‑processing a collection of CDR files to create logo assets with no background for use in presentations or marketing materials.
 * 4. When integrating Aspose.Imaging into a C# application that receives user‑uploaded CDR files and must strip the background before further image manipulation.
 * 5. When converting CDR designs to other formats and you need the background removed first to avoid unwanted color artifacts in the final output.
 */
