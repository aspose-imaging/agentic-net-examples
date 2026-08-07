using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.eps";
        string outputPath = @"C:\Temp\sample_converted.psd";

        try
        {
            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Create PSD save options (default settings)
                var psdOptions = new PsdOptions();

                // Save the image as PSD
                image.Save(outputPath, psdOptions);
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
 * 1. When a developer needs to integrate a workflow that converts vector EPS artwork into layered Photoshop PSD files for further editing in a C# application using Aspose.Imaging.
 * 2. When an automated batch process must read EPS logos from a file system and export them as PSD files to preserve editability for a design team's pipeline.
 * 3. When a web service written in .NET has to accept uploaded EPS files and return PSD versions on the fly without requiring external tools.
 * 4. When a desktop utility must verify the existence of an EPS source, create the output directory, and save the image as a PSD using default PsdOptions for compatibility with Adobe Photoshop.
 * 5. When a migration script needs to programmatically load legacy EPS assets and convert them to PSD format to standardize assets in a company's digital asset management system.
 */