using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected exceptions
        try
        {
            // Hardcoded input EPS file path
            string inputPath = @"C:\Temp\sample.eps";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output PSD file path
            string outputPath = @"C:\Temp\sample_converted.psd";

            // Ensure the output directory exists (creates it if missing)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image epsImage = Image.Load(inputPath))
            {
                // Prepare PSD saving options (default options are sufficient for size comparison)
                var psdOptions = new PsdOptions();

                // Save the image as PSD
                epsImage.Save(outputPath, psdOptions);
            }

            // Retrieve file sizes
            long epsSize = new FileInfo(inputPath).Length;
            long psdSize = new FileInfo(outputPath).Length;

            // Output the comparison result
            Console.WriteLine($"EPS file size: {epsSize} bytes");
            Console.WriteLine($"Converted PSD file size: {psdSize} bytes");
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
 * 1. When a developer needs to evaluate storage requirements before archiving vector EPS artwork alongside raster PSD versions in a digital asset management system.
 * 2. When a print production pipeline must decide whether converting EPS logos to PSD for Photoshop editing will significantly increase file size and affect server quotas.
 * 3. When a cloud‑based image processing service wants to benchmark the impact of EPS‑to‑PSD conversion on bandwidth consumption for client uploads.
 * 4. When a software vendor is performing a cost analysis to determine if storing both EPS source files and their PSD derivatives is feasible within a limited database space.
 * 5. When an automated build script must verify that converting EPS design files to PSD does not exceed predefined size thresholds for downstream processing.
 */