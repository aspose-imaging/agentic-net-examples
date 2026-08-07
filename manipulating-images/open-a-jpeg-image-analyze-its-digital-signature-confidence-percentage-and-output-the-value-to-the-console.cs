using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output/result.txt";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists before any possible save operation
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access digital‑signature methods
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("Loaded image does not support digital signature analysis.");
                    return;
                }

                // Analyze the digital signature confidence percentage.
                // An empty password is used when no specific password is known.
                int confidence = rasterImage.AnalyzePercentageDigitalSignature(string.Empty);

                // Output the result to the console
                Console.WriteLine($"Digital signature confidence: {confidence}%");

                // Also write the result to the output file
                File.WriteAllText(outputPath, $"Digital signature confidence: {confidence}%");
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected errors and report them
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application must verify the authenticity of a JPEG photograph received from a client by checking its digital signature confidence percentage before processing it further.
 * 2. When an automated image ingestion pipeline needs to log the digital signature confidence of each uploaded JPEG to ensure compliance with security policies.
 * 3. When a desktop utility for forensic analysts reads JPEG files and displays the digital signature confidence to help determine if the image has been tampered with.
 * 4. When a batch processing script validates a collection of JPEG images by writing the signature confidence values to a text report for audit purposes.
 * 5. When a cloud‑based service extracts metadata from JPEGs and includes the digital signature confidence percentage in the response to inform downstream image‑processing decisions.
 */