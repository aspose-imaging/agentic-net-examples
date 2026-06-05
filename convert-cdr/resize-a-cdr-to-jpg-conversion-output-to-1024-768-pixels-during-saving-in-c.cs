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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_converted.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Resize to the required dimensions (1024×768)
                image.Resize(1024, 768);

                // Save as JPEG using default JPEG options
                image.Save(outputPath, new JpegOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime error without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}