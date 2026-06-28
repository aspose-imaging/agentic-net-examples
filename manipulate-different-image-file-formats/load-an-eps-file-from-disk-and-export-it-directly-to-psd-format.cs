using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.eps";
        string outputPath = "output/sample.psd";

        try
        {
            // Verify that the input file exists
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
 * 1. When a graphic designer needs to convert vector EPS artwork into a layered Photoshop PSD file for further editing, a developer can use this C# code with Aspose.Imaging to load the EPS and save it as PSD.
 * 2. When an automated build pipeline must batch‑process EPS assets and generate PSD versions for a digital asset management system, the code provides a simple way to read each EPS file and export it directly to PSD in .NET.
 * 3. When a web application allows users to upload EPS logos and then download them as PSD files for brand‑consistent editing, the developer can employ this snippet to perform the conversion on the server side.
 * 4. When migrating legacy print‑ready EPS files to a modern Photoshop workflow, a developer can use the example to programmatically load the EPS and create PSD files with default options in C#.
 * 5. When a content‑creation tool needs to preview EPS illustrations as PSD layers without manual conversion, this code enables the tool to load the EPS and instantly save it as a PSD for quick viewing.
 */