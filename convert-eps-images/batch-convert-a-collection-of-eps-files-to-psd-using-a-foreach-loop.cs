using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of EPS files to convert
            string[] inputFiles = new string[]
            {
                @"C:\Images\Input1.eps",
                @"C:\Images\Input2.eps",
                @"C:\Images\Input3.eps"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same folder, .psd extension)
                string outputPath = Path.ChangeExtension(inputPath, ".psd");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image
                using (EpsImage image = (EpsImage)Image.Load(inputPath))
                {
                    // Prepare PSD save options (default settings)
                    var psdOptions = new PsdOptions();

                    // Save as PSD
                    image.Save(outputPath, psdOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When a graphic design workflow requires converting multiple Adobe Illustrator EPS assets into Photoshop PSD files for layer‑preserving editing, a developer can use this foreach loop to batch process the conversion in C#.
 * 2. When an automated build pipeline must generate PSD previews of EPS logos stored in a repository, the code enables the pipeline to verify file existence, create output directories, and save each image with Aspose.Imaging.
 * 3. When a web service needs to accept a list of uploaded EPS files and return PSD versions for downstream compositing, the snippet demonstrates how to iterate over the collection and perform the conversion safely.
 * 4. When a legacy printing system provides EPS artwork but the downstream workflow only supports PSD, this batch conversion routine lets developers quickly migrate the files without manual intervention.
 * 5. When a desktop utility is built to let users select multiple EPS files and convert them to PSD with default options, the foreach loop handles the per‑file loading, option setup, and error handling in a concise C# implementation.
 */